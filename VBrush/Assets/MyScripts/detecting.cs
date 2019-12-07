using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class detecting : MonoBehaviour, ITrackableEventHandler
{
    private TrackableBehaviour mTrackableBehaviour;
    private GameObject button2;
    private bool flag;


    public bool trackingCheck;

    public void OnTrackableStateChanged(
                            TrackableBehaviour.Status previousStatus,
                            TrackableBehaviour.Status newStatus)
    {
        if (newStatus == TrackableBehaviour.Status.TRACKED)
        {
            trackingCheck = true;
        }
        //else if(newStatus == TrackableBehaviour.Status.EXTENDED_TRACKED)
        //{
        //    trackingCheck = false;

        //    Renderer[] rendererComponents = GetComponentsInChildren<Renderer>(true);
        //    foreach (Renderer component in rendererComponents)
        //    {
        //        component.enabled = false;
        //    }
        //}
        else
        {
            if (trackingCheck == true)
            {
                trackingCheck = false;
            }
        }
    }


    void Start()
    {
        mTrackableBehaviour = GetComponent<TrackableBehaviour>();
        if (mTrackableBehaviour)
        {
            mTrackableBehaviour.RegisterTrackableEventHandler(this);
        }

        button2 = GameObject.Find("Button2");

        trackingCheck = false;
        flag = false;
    }

    void Update()
    {
        if (flag == false && button2.GetComponent<ChangeAnchor>().UDTChecker == true) // UDT 모드일때
        {
            flag = true;
            trackingCheck = false; // UDT로 갈때 마지막 tracking check를 꺼주어 안전하게           
        }
        else if (flag == true && button2.GetComponent<ChangeAnchor>().UDTChecker == false) // 앵커 모드일때
        {
            
            flag = false;
            //GetComponent<eraseClone>().EraseClones();
            mTrackableBehaviour.UnregisterTrackableEventHandler(this);
            mTrackableBehaviour.RegisterTrackableEventHandler(this); // 트래킹핸들러 껐다켜서 재트래킹 시키게
        }
    }
}
