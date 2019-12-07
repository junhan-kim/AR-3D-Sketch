using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class eraseClone : MonoBehaviour, IVirtualButtonEventHandler
{
    //private bool isPressed = false;
    public GameObject VBtn;

    public void EraseClones()
    {
        var clones = GameObject.FindGameObjectsWithTag("one");
        foreach (var clone in clones)
        {
            if (clone.name == "1(Clone)")
            {
                Destroy(clone);
            }
        }
    }

    public void OnButtonPressed(VirtualButtonBehaviour vb)
    {
        //isPressed = true;
        EraseClones();
    }

    public void OnButtonReleased(VirtualButtonBehaviour vb)
    {
        //isPressed = false;
    }

    // Start is called before the first frame update
    void Start()
    {
        VBtn = GameObject.Find("VButton1");

        VBtn.GetComponent<VirtualButtonBehaviour>().RegisterEventHandler(this);
    }

    // Update is called once per frame
    void Update()
    {
        //if (isPressed == true)
        //{
        //    EraseClones();
        //}
    }
}




