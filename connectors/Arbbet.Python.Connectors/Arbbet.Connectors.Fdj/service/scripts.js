/**
 * Parse the navigation menu to retrieve the list of available sports and competitions.
 * Note that the navigation elements needs to be clicked on to appear in the source and thus be exploitable.
 * */
function parseSportsAndCompetition() {
    // Opens all navigation links hidden, to load their content.
    jQuery('.ui-hidden').click();

    const menuElm = jQuery('#leftside-sportsbook')

    if (menuElm != null) {
        console.log('1:Found SportsBook')

        // Should we open the sports nav ?
        if (menuElm.find('h3.menu-group-title').hasClass('ui-closed')) {
            console.log('1:Opening SportsBook')
            menuElm.click();
        }

        menuElm.find('span.label-menu.leftside_menu_group_link-label--sportsbook').each(function () {
            let sport = jQuery(this).text();
            console.log(`2:Found Sport ${sport}`)

            if (jQuery(this).parent().parent().hasClass('item-arrow')) {
                if (!jQuery(this).parent().parent().hasClass('active')) {
                    console.log(`2:Opening Sport ${sport}`)
                    jQuery(this).click()
                }
            }

            jQuery(this).parent().parent().find('ul > li > a > span.label-menu').each(function () {
                let competition = jQuery(this).text()
                console.log(jQuery(this).text())
            })
        })
    }
}