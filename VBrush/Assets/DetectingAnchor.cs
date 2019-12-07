using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class DetectingAnchor : MonoBehaviour, ITrackableEventHandler
{
    private TrackableBehaviour mTrackableBehaviour;


    // Start is called before the first frame update
    void Start()
    {
        mTrackableBehaviour = GetComponent<TrackableBehaviour>();
        if (mTrackableBehaviour)
        {
            mTrackableBehaviour.RegisterTrackableEventHandler(this);
        }
    }


    public void OnTrackableStateChanged(
                            TrackableBehaviour.Status previousStatus,
                            TrackableBehaviour.Status newStatus)
    {
        if (newStatus == TrackableBehaviour.Status.TRACKED)
        {

        }
        else
        {
            Renderer[] rendererComponents = GetComponentsInChildren<Renderer>(true);
            foreach (Renderer component in rendererComponents)
            {
                component.enabled = false;
            }
        }
    }
}
