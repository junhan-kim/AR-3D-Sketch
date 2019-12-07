using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetBuilderAvailable : MonoBehaviour
{
    GameObject targetBuilderUI;
    GameObject button2;
    bool flag = false;

    void Start()
    {
        button2 = GameObject.Find("Button2");
        targetBuilderUI = GameObject.Find("TargetBuilderUI");
    }

    void Update()
    {
        if (flag == false && button2.GetComponent<ChangeAnchor>().UDTChecker == true)
        {
            targetBuilderUI.gameObject.SetActive(true);
            flag = true;
        }
        if (flag == true && button2.GetComponent<ChangeAnchor>().UDTChecker == false)
        {
            targetBuilderUI.gameObject.SetActive(false);
            flag = false;
        }
    }
    // 한번 비활성화시키면 스크립트자체도 비활성화되서 다시 활성화시킬 수가 없으므로 active작업을 수행할 오브젝트말고 외부의 다른 오브젝트에서 수행
}
