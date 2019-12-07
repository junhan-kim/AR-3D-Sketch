using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class Draw : MonoBehaviour, IVirtualButtonEventHandler{
    private bool isPressed = false;
    public GameObject VBtn;
    public GameObject Paint;
    public GameObject Brush;

    public GameObject MyButton;

    public void OnButtonPressed(VirtualButtonBehaviour vb)
    {
        isPressed = true;
    }

    public void OnButtonReleased(VirtualButtonBehaviour vb)
    {
        isPressed = false;
    }

    // Use this for initialization
    void Start () {
        VBtn = GameObject.Find("VButton");
        Brush = GameObject.Find("brush");

        MyButton = GameObject.Find("PushButton");
        
        VBtn.GetComponent<VirtualButtonBehaviour>().RegisterEventHandler(this);
        
    }
	
	// Update is called once per frame
	void Update () {
        //if (isPressed == true)
        
        // 유니티는 네임스페이스 쓰는 방식이 특이함.
        // using namespace 대신 그냥 using,   접두어 붙일땐 ::이 아니라 .
        if (MyButton.GetComponent<Ardunity.DigitalInput>().Value == true)
        {
            Instantiate(Paint, Brush.transform.position, Brush.transform.rotation);
        }
	}
}
