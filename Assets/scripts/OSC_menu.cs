using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OSC_menu : MonoBehaviour
{
    public GameObject oscmenu;
    public OSC osc;
    bool connected1 = false;
    bool connected2 = false;
    bool connected3 = false;
    bool connected4 = false;
    public Text text;

    int inPort = 8123;
    string outIP = "127.0.0.1";
    public void openOSC(bool open)
    {
        oscmenu.SetActive(open);
    }
     void Start()
    {
        osc.SetAddressHandler("/sensor/one", set_player1);
        osc.SetAddressHandler("/sensor/two", set_player2);
    }

    void Update(){
        print_connection();
    }

    void set_player1(OscMessage message)
    {
        connected1 = true;
    }

    void set_player2(OscMessage message)
    {
        connected2 = true;
    }

    void print_connection()
    {
        if (connected1 && connected2)
        {
            text.text = "both sensors are connected";
        }
        else 
        { 
            text.text = "..connecting";
        }
    }
    
    public void setinPort(string port)
    {
        inPort = System.Convert.ToInt32(port);
    } 

    public void setoutIP(string ip)
    {
        outIP = ip;
    }

    public void connect()
    {
        osc.outIP = outIP;
        osc.inPort = inPort;
    }
}

