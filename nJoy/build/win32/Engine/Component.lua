Component=class({
    ctor=function(self,gameObject)
        self._gameObject=gameObject
    end,
    property={
        gameObject={
            get=function(self)
                return self._gameObject
            end
        }
    }
})
