using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class DetectingUDT : MonoBehaviour, ITrackableEventHandler
{
    private TrackableBehaviour mTrackableBehaviour;
    private GameObject button2;  
    private bool flag;
    //private bool trackingCheckFlag = false;
    private GameObject Anchor;
    public bool UDTtrackingCheck;

    public void OnTrackableStateChanged(
                           TrackableBehaviour.Status previousStatus,
                           TrackableBehaviour.Status newStatus)
    {
        //if (newStatus == TrackableBehaviour.Status.TRACKED)
        //{
        //    UDTtrackingCheck = true;
        //}
        //else
        //{
        //    if (UDTtrackingCheck == true)
        //    {
        //        UDTtrackingCheck = false;
        //    }
        //}

        // if (newStatus == TrackableBehaviour.Status.TRACKED)
        //|| newStatus == TrackableBehaviour.Status.EXTENDED_TRACKED
        //|| newStatus == TrackableBehaviour.Status.DETECTED)

        //if (trackingCheckFlag == false)
        //{
        //   UDTtrackingCheck = true;
        //    trackingCheckFlag = true;
        //}

        //else if (newStatus == TrackableBehaviour.Status.EXTENDED_TRACKED)
        //{
        //    trackingCheck = false;

        ////    Renderer[] rendererComponents = GetComponentsInChildren<Renderer>(true);
        ////    foreach (Renderer component in rendererComponents)
        ////    {
        ////        component.enabled = false;
        ////    }
        ////}
        //else  // 다른 상태는 매우 많으므로 한번만
        //{
        //    //if (trackingCheckFlag == true)
        //    //{
        //    if (UDTtrackingCheck == true)
        //    {
        //        UDTtrackingCheck = false;
        //    }
        //        //trackingCheckFlag = false;
        //    //}
        //}
    }

    void Start()
    {
        mTrackableBehaviour = GetComponent<TrackableBehaviour>();
        if (mTrackableBehaviour)
        {
            mTrackableBehaviour.RegisterTrackableEventHandler(this);
        }

        button2 = GameObject.Find("Button2");
        Anchor = GameObject.Find("anchor");

        flag = false;
        UDTtrackingCheck = false;
    }

    // Update is called once per frame
    void Update()
    {
        //UDTtrackingCheck = true;
        if (flag == false && button2.GetComponent<ChangeAnchor>().UDTChecker == true) // UDT 모드일때
        {
            flag = true;
            Anchor.GetComponent<eraseClone>().EraseClones();
            mTrackableBehaviour.UnregisterTrackableEventHandler(this);
            mTrackableBehaviour.RegisterTrackableEventHandler(this);
            UDTtrackingCheck = true;
        }
        else if (flag == true && button2.GetComponent<ChangeAnchor>().UDTChecker == false) // Anchor 모드일때
        {
            flag = false;
            UDTtrackingCheck = false;
        }
    }
}
