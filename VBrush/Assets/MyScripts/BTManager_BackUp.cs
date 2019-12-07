using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ArduinoBluetoothAPI;
using System;
using UnityEngine.UI;

public class BTManager_BackUp : MonoBehaviour
{
    private BluetoothHelper BTHelper;
    public bool isPush;

    void Start()
    {
        isPush = false;

        BTHelper = BluetoothHelper.GetInstance("HC-06");       
        BTHelper.OnConnected += OnBluetoothConnected;
        BTHelper.OnDataReceived += () =>
        {            
            string str = BTHelper.Read();
            GetComponentInChildren<Text>().text = str;
            if(str[0] == 'P')
            {
                isPush = true;
            }
            else if(str[0] == 'U')
            {
                isPush = false;
            }
        };
        BTHelper.setTerminatorBasedStream("\n");

        while (!BTHelper.isDeviceFound())
        {
        }
        BTHelper.Connect();
    }

    void Update()
    {
        if(!BTHelper.isConnected())
        {
            BTHelper.Connect();
        }
    }


    void OnBluetoothConnected()
    {        
        BTHelper.StartListening();
    }

    void OnDestroy()
    {
        BTHelper.StopListening();
    }
}

