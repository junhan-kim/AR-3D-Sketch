using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class DetectingMarker : MonoBehaviour, ITrackableEventHandler
{
    private TrackableBehaviour mTrackableBehaviour;
    private GameObject FocusMessageBox;

    public void OnTrackableStateChanged(
                        TrackableBehaviour.Status previousStatus,
                        TrackableBehaviour.Status newStatus)
    {
        if (newStatus == TrackableBehaviour.Status.TRACKED)
        {
            
        }
        else // 트래킹 안된 상태면
        {
            Renderer[] rendererComponents = GetComponentsInChildren<Renderer>(true);

            foreach (Renderer component in rendererComponents) // 자식들 렌더링 해제(특히 마커가 표류현상이 심함)
            {
                component.enabled = false;
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

        FocusMessageBox = GameObject.Find("FocusMessageBox");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
