using Simple.Threading.Tasks;
using System;
using System.Collections;
using System.Linq;
using System.Threading.Tasks;
using UnityEngine;

public class Test : MonoBehaviour {

    private async void Start()
    {
        await Awaitable.Delay(1);

        var task = Awaitable.WaitCallback<int, string>(out var callback);
        CallbackFun(callback);
        var result = await task;
        Debug.Log($"Finish {string.Join(", ", result.Select((v) => Convert.ToString(v)))}");
    }

    void CallbackFun(Action<int, string> callback)
    {
        StartCoroutine(DoWait(callback));
    }

    IEnumerator DoWait(Action<int, string> callback)
    {
        Debug.Log("Do Wait");
        yield return new WaitForSeconds(1);
        Debug.Log("After Do Wait");
        callback?.Invoke(100, "wenkan");
    }
}
