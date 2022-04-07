using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityRawInput;

public class raw_input : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        var workInBackground = true;
        RawKeyInput.Start(workInBackground);
    }

    // Update is called once per frame
    void Update()
    {
       if (RawKeyInput.IsKeyDown(RawKey.W)) {
           print("key is down");
        } 
    }
}
