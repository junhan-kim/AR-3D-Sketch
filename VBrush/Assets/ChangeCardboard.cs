using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class ChangeCardboard : MonoBehaviour
{
    private bool isCardboard;
    // Start is called before the first frame update
    void Start()
    {
        isCardboard = false;
    }

    public void OnClickChangeCardboard()
    {
        if (!isCardboard)
        {
            isCardboard = true;
            MixedRealityController.Instance.SetMode(MixedRealityController.Mode.VIEWER_AR);  // 카드보드
        }
        else
        {
            isCardboard = false;
            MixedRealityController.Instance.SetMode(MixedRealityController.Mode.HANDHELD_AR);   // 일반(핸드헬드)
        }
    }

    // Update is called once per frame
    void Update()
    {
    }
}
