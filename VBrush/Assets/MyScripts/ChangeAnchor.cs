using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;
using UnityEngine.UI;

public class ChangeAnchor : MonoBehaviour
{
    private TrackableBehaviour anchorTB;
    private TrackableBehaviour userDefinedTargetTB;
    private GameObject targetBuilderUI;
    //private PositionalDeviceTracker pdt;

    public bool UDTChecker; // false = anchor
    public GameObject anchor;
    public GameObject userDefinedTarget;  
    public Transform nowTransform;
    

    void Start()
    {
        anchorTB = anchor.GetComponent<ImageTargetBehaviour>();
        userDefinedTargetTB = userDefinedTarget.GetComponent<ImageTargetBehaviour>();
        targetBuilderUI = GameObject.Find("TargetBuilderUI");
        //pdt = TrackerManager.Instance.GetTracker<PositionalDeviceTracker>();
        UDTChecker = false;

        // 시작 시에는 앵커임
        targetBuilderUI.transform.localScale = new Vector3(0, 0, 0);
        //pdt.Stop();
    }

    public void OnClickChangeAnchor()
    {
        if (UDTChecker == false)
        {
            VuforiaARController.Instance.SetWorldCenter(userDefinedTargetTB);
            UDTChecker = true;
            targetBuilderUI.transform.localScale = new Vector3(1, 1, 1);
            GetComponentInChildren<Text>().text = "UDT";
            //pdt.Start();
            nowTransform = userDefinedTarget.transform;        
        }
        else
        { 
            VuforiaARController.Instance.SetWorldCenter(anchorTB);
            UDTChecker = false;
            targetBuilderUI.transform.localScale = new Vector3(0, 0, 0);
            GetComponentInChildren<Text>().text = "anchor";
            //pdt.Stop();
            nowTransform = anchor.transform;
        }        
    }
}