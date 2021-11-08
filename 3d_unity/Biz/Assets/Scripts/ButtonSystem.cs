using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonSystem : MonoBehaviour
{

    int mPage = 0;
    int mPrevPage = 1;
    bool mTriggerFlag = true;

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

    // 페이지 계산
    public void PageAccumulator(int num)
    {
        mPage += num;
        mTriggerFlag = true;
    }
    // 페이지에 따른 버튼과 실제 페이지가 나타남
    void ButtonAppear()
    {
        SystemManager.Instance.ClothesSetting.Setting(mPage);

        transform.GetChild(mPage).gameObject.SetActive(true);
        transform.GetChild(mPrevPage).gameObject.SetActive(false);
        mPrevPage = mPage;
    }
}
