using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PhotonChat : Photon.MonoBehaviour
{
    public GameObject paint;
    public GameObject anchor;


    public void Send(PhotonTargets _target, string[] position, string[] rotation)
    {
        photonView.RPC("SendMsg", _target, position, rotation);
    }

    // position과 rotation 인자는 모든 연결된 클라이언트에서 공유된다.
    [PunRPC]
    void SendMsg(string[] position, string[] rotation, PhotonMessageInfo _info)
    {
        SetPointTransform(position, rotation);
    }

    void SetPointTransform(string[] position, string[] rotation)
    {
        Vector3 pointPosition = new Vector3(float.Parse(position[0]), float.Parse(position[1]), float.Parse(position[2]));
        Quaternion pointRotation = new Quaternion(float.Parse(rotation[0]), float.Parse(rotation[1]), float.Parse(rotation[2]), float.Parse(rotation[3]));
        Instantiate(paint, pointPosition, pointRotation).transform.SetParent(anchor.transform);
    }
}
