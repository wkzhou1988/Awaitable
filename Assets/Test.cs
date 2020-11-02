using Simple.Threading.Tasks;
using System;
using System.Collections;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using UnityEngine;
using Debug = UnityEngine.Debug;

public class Test : MonoBehaviour {

    private async void Start()
    {
        await Task.Delay(TimeSpan.FromSeconds(1));
        var sw = Stopwatch.StartNew();
        var delay = Awaitable.Delay(2);
        var returnvalue = doawait();
        CallbackFun(Awaitable.WaitCallback<int, string>(out var callback));
        await Awaitable.WhenAll(delay, returnvalue, callback);
        Debug.Log($"time passed {sw.ElapsedMilliseconds}");
        Debug.Log($"delay {await delay}");
        Debug.Log($"returnvalue {await returnvalue}");
        Debug.Log($"callback {await callback}");
    }

    async AwaitableTask<int> doawait() {
        await Awaitable.Delay(1);
        return 100;
    }

    void CallbackFun(Action<int, string> callback)
    {
        StartCoroutine(DoWait(callback));
    }

    IEnumerator DoWait(Action<int, string> callback)
    {
        Debug.Log("Do Wait");
        yield return new WaitForSeconds(3);
        Debug.Log("After Do Wait");
        callback?.Invoke(100, "wenkan");
    }
}
