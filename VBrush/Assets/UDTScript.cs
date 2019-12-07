using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;
using UnityEngine.UI;

public class UDTScript : MonoBehaviour, ITrackableEventHandler
{
    private TrackableBehaviour mTrackableBehaviour;
    private TrackableBehaviour.Status status;

    public bool isUDTLost;


    public void OnTrackableStateChanged(
                           TrackableBehaviour.Status previousStatus,
                           TrackableBehaviour.Status newStatus)
    {
        //isUDTLost = false;
        if (newStatus == TrackableBehaviour.Status.TRACKED)
        {
            //isUDTLost = false;
            status = TrackableBehaviour.Status.TRACKED;
            //GetComponentInChildren<Text>().text = "Tr";

            // 일단 이 섹션을 가지고 ET 상태를 제어할 수도 있을듯
            //var rendererComponents = GetComponentsInChildren<Renderer>(true);
            //foreach (var component in rendererComponents)
            //    component.enabled = true;
        }
        else if (newStatus == TrackableBehaviour.Status.EXTENDED_TRACKED)
        {
            //isUDTLost = false; // 그담에 아래꺼도 false해보자
            status = TrackableBehaviour.Status.EXTENDED_TRACKED;
            //GetComponentInChildren<Text>().text = "Ex";

            //var rendererComponents = GetComponentsInChildren<Renderer>(true);
            //foreach (var component in rendererComponents)
            //    component.enabled = true;
            //var rendererComponents = GetComponentsInChildren<Renderer>(true);
            //foreach (var component in rendererComponents)
            //    component.enabled = false;
        }
        else // Tr되고 status 바꼈는데 즉시 EX말고 다른 상태가 선점해서 TR은 남아잇는데 isUDTLost가 true가 되어 안그려지는걸수도 있음
             // 이 말인 즉슨, TRACKED 상태가 UDT에서 거의 존재하지 않는다는 거일 수도 잇음.  그게 맞다면 이건 답이없음
        {
            //isUDTLost = false;
            //GetComponentInChildren<Text>().text = "Et";

            //var rendererComponents = GetComponentsInChildren<Renderer>(true);
            //foreach (var component in rendererComponents)
            //    component.enabled = true;
            //var rendererComponents = GetComponentsInChildren<Renderer>(true);
            //foreach (var component in rendererComponents)
            //    component.enabled = false;
        }
    }

    // 스타트가 반복되어서 isUDTLost가 갱신될수도있음
    void Start()
    {       
        mTrackableBehaviour = GetComponent<TrackableBehaviour>();
        if (mTrackableBehaviour)
        {
            mTrackableBehaviour.RegisterTrackableEventHandler(this);
        }
        isUDTLost = true;
    }


    void Update()
    {
        //isUDTLost = false;
        if (status == TrackableBehaviour.Status.TRACKED || status == TrackableBehaviour.Status.EXTENDED_TRACKED)
        {
            isUDTLost = false;
            //GetComponentInChildren<Text>().text = "Tr";
        }
        //else if (status == TrackableBehaviour.Status.EXTENDED_TRACKED)
        //{
        //    Renderer[] rendererComponents = GetComponentsInChildren<Renderer>();
        //    foreach (Renderer component in rendererComponents)
        //    {
        //        component.enabled = false;
        //    }
        //}
    }
}