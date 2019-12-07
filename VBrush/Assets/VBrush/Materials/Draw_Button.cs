using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using Vuforia;

public class Draw_Button : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    private bool isDrawButtonPushed;
    private BTManager_BackUp scriptBTManager_BackUp;
    //private ChangeAnchor scriptChangeAnchor;
    private penCylScript scriptPenCylScript;
    private AnchorScript scriptAnchorScript;
    //private UDTScript scriptUDTScript;
    private PhotonChat scriptPhotonChat;

    public GameObject paint;
    public GameObject brush;
    public GameObject anchor;
    //public GameObject userDefinedTarget;
    public GameObject anchor_plane;
    public GameObject anchor_midair;
    public bool isGroundPlane;

    public void OnPointerDown(PointerEventData eventData)
    {
        isDrawButtonPushed = true;
    }
    public void OnPointerUp(PointerEventData eventData)
    {
        isDrawButtonPushed = false;
    }

    public void ChangeToGroundPlane()
    {
        isGroundPlane = true;
    }

    public void ChangeToMidAir()
    {
        isGroundPlane = false;
    }


    void Start()
    {
        isDrawButtonPushed = false;
        scriptBTManager_BackUp = GameObject.Find("BluetoothManager").GetComponent<BTManager_BackUp>();
        //scriptChangeAnchor = GameObject.Find("Button2").GetComponent<ChangeAnchor>();
        scriptPenCylScript = GameObject.Find("penCyl").GetComponent<penCylScript>();
        scriptAnchorScript = GameObject.Find("anchor").GetComponent<AnchorScript>();
        //scriptUDTScript = GameObject.Find("UserDefinedTarget").GetComponent<UDTScript>();
        scriptPhotonChat = GameObject.Find("PhotonManager").GetComponent<PhotonChat>();
        isGroundPlane = true;
    }


    void Update()
    { 
        //if ((isDrawButtonPushed) || (scriptBTManager_BackUp.isPush))
        //{
        //    if (!scriptPenCylScript.isBrushLost)
        //    {
        //        if(!scriptChangeAnchor.UDTChecker)
        //        {
        //            if (!scriptAnchorScript.isAnchorLost)
        //            {
        //                // 현재 모드에 따라 anchor 또는 UDT를 부모로 하여 복사한다.
        //                Instantiate(paint, brush.transform.position, brush.transform.rotation).transform.SetParent(scriptChangeAnchor.nowTransform);
        //            }
        //        }
        //        else
        //        {
        //            //if(!scriptUDTScript.isUDTLost)
        //            {
        //                Instantiate(paint, brush.transform.position, brush.transform.rotation).transform.SetParent(scriptChangeAnchor.nowTransform);
        //            }
        //        }
        //    }
        //}

        if (isDrawButtonPushed || scriptBTManager_BackUp.isPush)
        {
            if (!scriptPenCylScript.isBrushLost)
            {
                if (!scriptAnchorScript.isAnchorLost)    // => 앵커 모드
                {
                    Transform brushTransform = brush.transform;
                    Instantiate(paint, brush.transform.position, brush.transform.rotation).transform.SetParent(anchor.transform); // 서버에 연결되어있지 않더라도 그릴 수 있게.
                    // Shared AR 시작 부분.
                    string[] strPosition = { brushTransform.position.x.ToString(), brushTransform.position.y.ToString(), brushTransform.position.z.ToString() };
                    string[] strRotation = { brushTransform.rotation.x.ToString(), brushTransform.rotation.y.ToString(), brushTransform.rotation.z.ToString(), brushTransform.rotation.w.ToString() };
                    scriptPhotonChat.Send(PhotonTargets.All, strPosition, strRotation);
                }

                //if(isGroundPlane)  // => GP 모드
                //{
                //    Instantiate(paint, brush.transform.position, brush.transform.rotation).transform.SetParent(anchor_plane.transform);
                //}
                //else  // => MA 모드
                //{
                //    Instantiate(paint, brush.transform.position, brush.transform.rotation).transform.SetParent(anchor_midair.transform);
                //}
            }
        }
    }
}