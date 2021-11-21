using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonSystem : MonoBehaviour
{

    int mPage = 0;
    int mPrevPage = 1;
    bool mTriggerFlag = true;

    int LASTPAGE = 3;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (mTriggerFlag)
        {
            ButtonAppear();
            mTriggerFlag = false;
        }
    }

    // ������ ���
    public void PageAccumulator(int num)
    {
        mPage += num;
        mTriggerFlag = true;
    }
    // �������� ���� ��ư�� ���� �������� ��Ÿ��
    void ButtonAppear()
    {
        SystemManager.Instance.GetCurrentSceneMain<InGameSceneMain>().ClothesSetting.Setting(mPage);

        // ���� ù�������̰ų� �������������ϰ�� ��ư ��Ÿ�� ���
        if (mPage == 0)
        {
            transform.GetChild(0).gameObject.SetActive(true);
            transform.GetChild(1).gameObject.SetActive(false);
        }
        else if (mPage == LASTPAGE)
        {
            transform.GetChild(1).gameObject.SetActive(true);
            transform.GetChild(0).gameObject.SetActive(false);
        }
        else
        {
            transform.GetChild(0).gameObject.SetActive(true);
            transform.GetChild(1).gameObject.SetActive(true);
        }
        
    }
}
