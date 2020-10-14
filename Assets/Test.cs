using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Simple.Threading.Tasks;

public class Test : MonoBehaviour
{
    // Start is called before the first frame update
    async void Start()
    {
        Debug.Log("1111");
        var t = Awaitable.Delay(1);
        await t;
        Debug.Log("2222");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
