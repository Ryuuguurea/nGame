require"Native"
onError=function(...)
    print(...)
    print(debug.traceback())
end

package.path=package.path ..";Engine/?.lua"
local window=Window:new("GameGeninus",600,400)
local game= require"Engine/Game"
game.Resize(600,400)
window:SetFramebufferSizeCallback(function(...)
    game.Resize(...)
end)
 
window:SetCursorPosCallback(function(x,y)
    Input._mousePosition=Vector3:new(x,y)
end)
window:SetScrollCallback(function(x,y)
    Input._mouseScroll=Vector3:new(x,y)
end)
window:SetMouseButtonCallBack(function(a,b,c)
    Input._mouseButton[a]=b
end)


xpcall(game.Start,onError)
mainLoop=function()
    Time:Update(Window.GetTime())
    game.Update(Time.deltaTime)
    window:SwapBuffers()
    Input._mouseScroll=Vector3:new()
    Window.PollEvents()
end

while not window:WindowShouldClose() do
    xpcall(mainLoop,onError)
end