using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro; 

public class text : MonoBehaviour
{

    public void Init(bool isRightScript)
    {
        Vector3 pos = Vector3.zero;

        if (!isRightScript)
        {
            pos = new Vector3(2, 0.51f, 3);
        }
        else if (isRightScript)
        {
            pos = new Vector3(-2f, 0.51f, 3);
        }

        transform.position = pos;

    }

    public void writeScore(int score)
    {
        
        GetComponent<TextMeshPro>().text = score.ToString();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
