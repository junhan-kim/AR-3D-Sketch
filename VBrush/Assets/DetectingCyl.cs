using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;


public class DetectingCyl : MonoBehaviour, ITrackableEventHandler
{
    private TrackableBehaviour mTrackableBehaviour;
    private GameObject focusMessageBox;
    private bool flag;
    //private Renderer[] rendererComponents;
    private bool isRender;

    public void OnTrackableStateChanged(
                       TrackableBehaviour.Status previousStatus,
                       TrackableBehaviour.Status newStatus)
    {
        if (newStatus == TrackableBehaviour.Status.TRACKED)
        {
            
            if (flag == false)
            {
                flag = true;
                //isRender = true;
                focusMessageBox.transform.localScale = new Vector3(0, 0, 0);
            }
        }
        else // 트래킹 안된 상태면
        {          
            if (flag == true)
            {
                flag = false;
                //isRender = false;
                focusMessageBox.transform.localScale = new Vector3(0.1f, 0.05f, 1);
                //foreach (Renderer component in rendererComponents) // 자식들 렌더링 해제(특히 마커가 표류현상이 심함)
                //{
                //    component.enabled = false;
                //}
            }
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        mTrackableBehaviour = GetComponent<TrackableBehaviour>();
        if (mTrackableBehaviour)
        {
            mTrackableBehaviour.RegisterTrackableEventHandler(this);
        }

        focusMessageBox = GameObject.Find("FocusMessageBox");
        flag = false;
        //rendererComponents = GetComponentsInChildren<Renderer>(true);
        isRender = GameObject.Find("brush").GetComponent<SpriteRenderer>().enabled;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
