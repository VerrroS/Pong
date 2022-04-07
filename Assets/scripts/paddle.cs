using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityRawInput;

public class paddle : MonoBehaviour

{
    string input;
    public float speed = 4;
    float height;
    bool isRight;
    float move;
    float x;
    public bool useSensors = true;

    // Start is called before the first frame update
    void Start()
    {
        
        OSC osc = FindObjectOfType<OSC>();
        osc.SetAddressHandler("/sensor/one", set_player1);
        osc.SetAddressHandler("/sensor/two", set_player2);
        
        height = transform.localScale.y;
        var workInBackground = true;
        RawKeyInput.Start(workInBackground);
    }


    public void Init(bool isRightPaddle)
    {
        Vector2 pos = Vector2.zero;


        if (isRightPaddle)
        {
            // Place paddle on the right of screen
            pos = new Vector3((GameManager.width/2), 1, 0);
            pos -= Vector2.right * (transform.localScale.x);
            isRight = true;
            input = "PaddleRight";
            transform.name = input;

        }
        else
        {
            // Place paddle on the left of screen
            pos = new Vector3((-GameManager.width/2), 1, 0);
            pos += Vector2.right * (transform.localScale.x );
            input = "PaddleLeft";
            isRight = false;
            transform.name = input;
        }

        transform.position = pos;

    }

    // Update is called once per frame
    void Update()
    {
        if (useSensors)
        {
            move = x * Time.deltaTime * speed;
        }
        else
        {
            if (!isRight)
            {
                if (RawKeyInput.IsKeyDown(RawKey.W)){
                    x = 1;
                }
                else if (RawKeyInput.IsKeyDown(RawKey.S)){
                    x = -1;
                }
                else{
                    x = 0;
                }
            if (isRight){
                if (RawKeyInput.IsKeyDown(RawKey.Up)){
                    x = 1;
                }
                else if (RawKeyInput.IsKeyDown(RawKey.Down)){
                    x = -1;
                }
                else{
                    x = 0;
                }
            }
            }
            move = Input.GetAxis(input) * Time.deltaTime * speed;

        }

        transform.Translate(move * Vector3.forward);
        if(transform.position.z >= GameManager.height/2)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, GameManager.height / 2);
        }
        if(transform.position.z <= -GameManager.height/2)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, -GameManager.height / 2);
        }
    }

    int get_direction(float x){
        if (x > 0 )
        {
            x = 1;
        }
        else if (x > 0)
        {
            x = -1;
        }
        return (int)x;
    }

    void set_player1(OscMessage message)
    {
        if (isRight) {
            
            x = get_direction((float)message.GetInt(0)/(float)16000);
        }
    }

    void set_player2(OscMessage message)
    {
        if (!isRight)
        {
            x = get_direction((float)message.GetInt(0)/(float)16000);
        }
    }
    public void setSpeed(float newSpeed)
    {
        speed = newSpeed;
    }

    public void setSensor(bool use)
    {
        useSensors = use;
    }

}


    

