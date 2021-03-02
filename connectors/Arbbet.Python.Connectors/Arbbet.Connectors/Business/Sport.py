class Sport(object):
    def __init__(self, id, code, name, idfdj):
        self.id = id
        self.code = code
        self.name = name
        self.idfdj = idfdj

    @property
    def id(self):
        return self._id

    @id.setter
    def id(self, value):
        self._id = value

    @property
    def name(self):
        return self._name

    @name.setter
    def name(self, value):
        self._name = value

    @property
    def code(self):
        return self._code

    @code.setter
    def code(self, value):
        self._code = value

    @property
    def idfdj(self):
        return self._idfdj

    @idfdj.setter
    def idfdj(self, value):
        self._idfdj = value