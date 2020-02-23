using System.Threading.Tasks;
using UnityEngine;
using System.Runtime.CompilerServices;
using UnityEngine.Networking;
public static class AwaitExtensions{
    public static TaskAwaiter<AsyncOperation> GetAwaiter(this AsyncOperation obj){

        System.Action<AsyncOperation> callback=null;
        AsyncOperation operation=null;
        System.Func<AsyncOperation> resolve=()=>{
            return operation;
        };
        Task<AsyncOperation> task=new Task<AsyncOperation>(resolve);
        callback=(op)=>{
            obj.completed-=callback;
            operation=op;
            task.Start();
        };
        obj.completed+=callback;
        return task.GetAwaiter();
    }  
}