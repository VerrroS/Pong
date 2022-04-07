using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bound : MonoBehaviour
{

    public void Init(int side)
    {
        Vector3 pos = Vector2.zero;
        Vector3 scaleChange = Vector3.zero;
        Quaternion rotationChange;

        if (side == 1 | side == 2)
        {
            scaleChange = new Vector3(GameManager.width, 1, 15);
            transform.localScale = scaleChange;
            if (side == 1)
            {
                pos = new Vector3(0, 0, GameManager.height / 2);
                pos += Vector3.forward * (transform.localScale.y *2);
            }
            if (side == 2)
                pos = new Vector3(0, 0, -GameManager.height / 2);
                pos -= Vector3.forward * (transform.localScale.y);
            print(Vector3.forward);
        }
        if (side == 3 | side == 4)
        {
            scaleChange = new Vector3(GameManager.height, 1, 15);
            transform.localScale = scaleChange;
            rotationChange = Quaternion.Euler(90, 90, 0);

            if (side == 3)
            {
                pos = new Vector3(GameManager.width/2, 0, 0);
                pos += Vector3.right * (transform.localScale.y);
                gameObject.tag = "Player1";
            }
            if (side == 4)
            {
                pos = new Vector3(-GameManager.width/2, 0, 0);
                pos -= Vector3.right * (transform.localScale.y);
                gameObject.tag = "Player2";
            }

            transform.rotation = rotationChange;
        }
        transform.position = pos;

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
