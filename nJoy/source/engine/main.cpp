#include "luabinding/ScriptUtil.h"

int main(int argc, char *argv[])
{
    ScriptUtil* su=new ScriptUtil(argc,argv);
    su->Run("main.lua");
    return 0;
}
