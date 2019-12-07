using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using Vuforia;
using UnityEngine.UI;

public class lightON : MonoBehaviour//, IPointerDownHandler, IPointerUpHandler
{
    private bool check;

    //public void OnPointerDown(PointerEventData eventData)
    //{
    //    check = true;
    //}
    //public void OnPointerUp(PointerEventData eventData)
    //{
    //    check = false;
    //}

    public void OnClickLight()
    {
        if (check == true)
        {
            check = false;
            GetComponentInChildren<Text>().text = "off";
        }
        else
        {
            check = true;
            GetComponentInChildren<Text>().text = "on";
        }

        CameraDevice.Instance.SetFlashTorchMode(check);     
    }


    void Start()
    {
        check = false;
    }

    void Update()
    {
    }
}
