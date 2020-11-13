EditorCamera=class{
    ctor=function(self)
        self._lastMouse={x=0,y=0}
        self._mouseLock={
            true,
            true
        }
        self._startAngle=Vector3:new()
    end,
    property={
        Update=function(self)
            local delta=Vector3:new(Input.mousePosition.x-self._lastMouse.x,Input.mousePosition.y-self._lastMouse.y,0)
            self._lastMouse=Input.mousePosition
            if Input:GetMouseButton(1) then
                if self._mouseLock[1] then
                    self._mouseLock[1]=false
                    return
                end
                self._startAngle=self._startAngle-Vector3:new(delta.y*0.005,delta.x*0.005)
                self.gameObject.transform.localRotation=Quaternion:Euler(self._startAngle)
            else
                self._mouseLock[1]=true
            end
            if Input:GetMouseButton(2)then
                if self._mouseLock[2] then
                    self._mouseLock[2]=false
                    return
                end
                local p=self.gameObject.transform.rotation*Vector3:new(-delta.x*0.05,delta.y*0.05)
                self.gameObject.transform.position=self.gameObject.transform.position+self.gameObject.transform.rotation*Vector3:new(-delta.x*0.05,delta.y*0.05)
            else
                self._mouseLock[2]=true
            end
            if Input.mouseScroll.y~=0 then
                self.gameObject.transform.position=self.gameObject.transform.position+self.gameObject.transform.rotation*Vector3:new(0,0,Input.mouseScroll.y*0.5)
            end
        end
    },
    extend=Component
}