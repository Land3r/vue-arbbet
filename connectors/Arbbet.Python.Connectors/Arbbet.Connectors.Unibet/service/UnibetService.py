import os, platform, subprocess, sys
from urllib.parse import urljoin
import requests
import logging
import json
from types import SimpleNamespace
from cefpython3 import cefpython as cef

VIEWPORT_SIZE = (1024, 860)
browser_settings = {
    # Tweaking OSR performance (Issue #240)
    "windowless_frame_rate": 30,  # Default frame rate in CEF is 30
}
baseUrl = 'https://www.unibet.fr/sport'

endpointUrl = {
    'offre': '1n2/offre?sport={0}'
}

class UnibetService(object):
    def __init__(self, *args, **kwargs):

        # Registers error hook.
        sys.excepthook = cef.ExceptHook

        # Configures engine.
        settings = {
            "windowless_rendering_enabled": False,
        }
        switches = {
            # GPU acceleration is not supported in OSR mode, so must disable
            # it using these Chromium switches (Issue #240 and #463)
            "disable-gpu": "",
            "disable-gpu-compositing": "",
            # Tweaking OSR performance by setting the same Chromium flags
            # as in upstream cefclient (Issue #240).
            "enable-begin-frame-scheduling": "",
            "disable-surfaces": "",  # This is required for PDF ext to work
        }
        cef.Initialize(settings=settings, switches=switches)
        
    def getSportsAndCompetitions(self):
        url = baseUrl

        self.create_browser(browser_settings, url)
        cef.MessageLoop()
        cef.Shutdown()
        logging.debug('Closing CEF')

    def getOffre(sportId):

        if (sportId == None):
            raise Exception('sportId is null')

        url = urljoin(baseUrl, endpointUrl.get('offre').format(sportId))
        r = requests.get(url)
        
        if r.status_code == 200:
            logging.debug(r.text)
            res_object = json.loads(r.text, object_hook=lambda d: SimpleNamespace(**d))
            return res_object

        elif r.status_code == 204:
            return []

        elif r.status_code == 400:
            return

        else:
            return r

    def create_browser(self, settings, url):
        # Create browser in off-screen-rendering mode (windowless mode)
        # by calling SetAsOffscreen method. In such mode parent window
        # handle can be NULL (0).
        parent_window_handle = 0
        window_info = cef.WindowInfo()
        window_info.SetAsChild(parent_window_handle)
        print("[screenshot.py] Viewport size: {size}"
              .format(size=str(VIEWPORT_SIZE)))
        print("[screenshot.py] Loading url: {url}"
              .format(url=baseUrl))
        browser = cef.CreateBrowserSync(window_info=window_info,
                                        settings=settings,
                                        url=url)
        browser.SetClientHandler(LoadHandler())
        browser.SetClientHandler(RenderHandler())
        browser.SendFocusEvent(True)
        # You must call WasResized at least once to let know CEF that
        # viewport size is available and that OnPaint may be called.
        browser.WasResized()

class LoadHandler(object):
    def OnLoadingStateChange(self, browser, is_loading, **_):
        """Called when the loading state has changed."""
        if not is_loading:
            # Loading is complete
            sys.stdout.write(os.linesep)
            print("[screenshot.py] Web page loading is complete")
            print("[screenshot.py] Will save screenshot in 2 seconds")
            # Give up to 2 seconds for the OnPaint call. Most of the time
            # it is already called, but sometimes it may be called later.
            #cef.PostDelayedTask(cef.TID_UI, 2000, save_screenshot, browser)

    def OnLoadError(self, browser, frame, error_code, failed_url, **_):
        """Called when the resource load for a navigation fails
        or is canceled."""
        if not frame.IsMain():
            # We are interested only in loading main url.
            # Ignore any errors during loading of other frames.
            return
        print("[screenshot.py] ERROR: Failed to load url: {url}"
              .format(url=failed_url))
        print("[screenshot.py] Error code: {code}"
              .format(code=error_code))
        # See comments in exit_app() why PostTask must be used
        cef.PostTask(cef.TID_UI, exit_app, browser)


class RenderHandler(object):
    def __init__(self):
        self.OnPaint_called = False

    def GetViewRect(self, rect_out, **_):
        """Called to retrieve the view rectangle which is relative
        to screen coordinates. Return True if the rectangle was
        provided."""
        # rect_out --> [x, y, width, height]
        rect_out.extend([0, 0, VIEWPORT_SIZE[0], VIEWPORT_SIZE[1]])
        return True

    def OnPaint(self, browser, element_type, paint_buffer, **_):
        """Called when an element should be painted."""
        if self.OnPaint_called:
            sys.stdout.write(".")
            sys.stdout.flush()
        else:
            sys.stdout.write("[screenshot.py] OnPaint")
            self.OnPaint_called = True
        if element_type == cef.PET_VIEW:
            # Buffer string is a huge string, so for performance
            # reasons it would be better not to copy this string.
            # I think that Python makes a copy of that string when
            # passing it to SetUserData.
            buffer_string = paint_buffer.GetBytes(mode="rgba",
                                                  origin="top-left")
            # Browser object provides GetUserData/SetUserData methods
            # for storing custom data associated with browser.
            browser.SetUserData("OnPaint.buffer_string", buffer_string)
        else:
            raise Exception("Unsupported element_type in OnPaint")

def exit_app(browser):
    # Important note:
    #   Do not close browser nor exit app from OnLoadingStateChange
    #   OnLoadError or OnPaint events. Closing browser during these
    #   events may result in unexpected behavior. Use cef.PostTask
    #   function to call exit_app from these events.
    print("[screenshot.py] Close browser and exit app")
    browser.CloseBrowser()
    cef.QuitMessageLoop()