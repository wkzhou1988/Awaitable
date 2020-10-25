using Simple.Threading.Tasks;
using System;
using System.Threading.Tasks;
using UnityEngine;

public class Test : MonoBehaviour {

    private async void Start() {
        await Task.Delay(TimeSpan.FromSeconds(1));
        Debug.Log("0000");
        var i = await Do();
        Debug.Log($"3333 {i}");
    }

    private async BaseAwaitableTask<int> Do() {
        Debug.Log("1111");
        await Awaitable.Delay(1);
        Debug.Log("2222");
        return 1;
    }
}
