using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;
using UnityEngine.UI;

public class AnchorScript : MonoBehaviour, ITrackableEventHandler
{
    private TrackableBehaviour mTrackableBehaviour;
    //private TrackableBehaviour.Status status;

    public bool isAnchorLost;


    public void OnTrackableStateChanged(
                           TrackableBehaviour.Status previousStatus,
                           TrackableBehaviour.Status newStatus)
    {
        // 다시 TRACKED가 되어지면 명시적 Re-렌더링을 하지 않아도, 매 프레임마다 다시 그리기 때문에 어차피 다시 보임
        if (newStatus == TrackableBehaviour.Status.TRACKED)
        {
            isAnchorLost = false;          
            //status = TrackableBehaviour.Status.TRACKED;
            //GetComponentInChildren<Text>().text = "Tr";
        }
        // 정확한건 아니지만 Ex상태에도 Text가 Enable = false 되지 않는 이유는 Text에 렌더러가 없어서라고 가정하자.
        //else if (newStatus == TrackableBehaviour.Status.EXTENDED_TRACKED)
        //{
        //    isAnchorLost = true;
        //    status = TrackableBehaviour.Status.EXTENDED_TRACKED;
        //}        
        else
        {
            isAnchorLost = true;
        }
    }


    void Start()
    {
        mTrackableBehaviour = GetComponent<TrackableBehaviour>();
        if (mTrackableBehaviour)
        {
            mTrackableBehaviour.RegisterTrackableEventHandler(this);
        }
        isAnchorLost = true;
    }


    void Update()
    {
            // 어째서 콜백함수 내에서는 이 블록이 작동 안하는지 모르겠음.  임시적으로 업데이트 내에서 수행하도록 함.
            // 1. ET(Extended Tracking) 상태에서 잔여 현상(트래킹이 해제 되었는데도 자식 객체가 남아있는 현상) 발생
            //      -> 이 블록을 통해 ET 상태에 진입하면 렌더링을 전부 해제함 
            // (유추해보자면, 뷰포리아는 매 프레임마다 렌더링을 해제하고 다시 그릴 것임. 왜냐면 프레임마다 가상 객체의 위치,각도가 변하므로)
            // (그래서 StateChanged 콜백에서 한번 수행하는 건 금새 덮어 씌워지므로, 업데이트에서 해당 상태일때 계속해서 수행하게 해야함)
            // 2. 트래킹된 객체에서 화면을 급격히 이탈시켜서 일단 Tracking이 한번 Lost되면, 이런 함수 수행없이도 어차피 ET에 진입하지 않는다.
            //    다만 이는 영구적인 것은 아니고, 이탈 시키는 행위를 한번 더 하게 되면 초기상태로 돌아감.
        //if (status == TrackableBehaviour.Status.EXTENDED_TRACKED)
        //{
        //    Renderer[] rendererComponents = GetComponentsInChildren<Renderer>();
        //    foreach (Renderer component in rendererComponents)
        //    {
        //        component.enabled = false;
        //    }
        //}
    }
}
