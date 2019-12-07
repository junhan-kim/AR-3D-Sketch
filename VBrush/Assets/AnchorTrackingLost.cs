using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnchorTrackingLost : DefaultTrackableEventHandler
{
    // Start is called before the first frame update


    private void OnTrackingFound()
    {
        base.OnTrackingFound();
        // extra behaviour here
    }

    private void OnTrackingLost()
    {
        base.OnTrackingLost();
        // extra behaviour here
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
