using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour
{
    [SerializeField]
    GameObject CompleteButton;

    const float DRAGCRITERION = 1.0f;
    GameObject mTouchObj;
    Vector3 mMousePos = Vector3.zero;
    bool mDragingFlag = false;

    public bool DragingFlag
    {
        get
        {
            return mDragingFlag;
        }
        set
        {
            mDragingFlag = value;
        }
    }

    GameObject mClickButtonObj;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        DragAndDrop();
        ButtonClick();
    }

    

    // �巡�� �� ���
    void DragAndDrop()
    {
        // ��ġ �νĵǰ�, �� ��ġ�� ������Ʈ�̸�
        if (Input.GetMouseButton(0) && TouchIsObj(out mTouchObj, ClothesRecognition))
        {
            // ��ġ�� �̲����� ������ ������Ʈ�� �i�ư���
            mMousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mMousePos.z = Cloth.ZPOS - DRAGCRITERION; // �巡�� ���� ����
            mTouchObj.GetComponent<Cloth>().InputMoveVector(mMousePos);
            CompleteButton.SetActive(false);

            mDragingFlag = true;

        }
        else
        {
            if (!SystemManager.Instance.GetCurrentSceneMain<InGameSceneMain>().GamePointAccumulator.Complete)
            {
                CompleteButton.SetActive(true);
            }
            
            mDragingFlag = false;
        }

    }
    // ��ư Ŭ�� �� �̺�Ʈ �߻�
    void ButtonClick()
    {
        if (Input.GetMouseButtonDown(0) && TouchIsObj(out mClickButtonObj, ButtonRecognition))
        {
            if (mClickButtonObj.name.Contains("LB"))
            {
                SystemManager.Instance.GetCurrentSceneMain<InGameSceneMain>().ButtonSystem.PageAccumulator(-1);
            }
            else
            {
                SystemManager.Instance.GetCurrentSceneMain<InGameSceneMain>().ButtonSystem.PageAccumulator(1);
            }
        }
    }
    // �� ��ġ�� �ش� ������Ʈ�̸� 1, �ƴϸ� 0
    bool TouchIsObj(out GameObject touchObj, FunctionPointer recognition)
    {
        RaycastHit hit;
        Ray touchray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Physics.Raycast(touchray, out hit);

        if (hit.collider != null)
        {
            if (recognition(hit))
            {
                touchObj = hit.collider.gameObject;
                return true;
            }
        }

        touchObj = null;
        return false;
    }


    public delegate bool FunctionPointer(RaycastHit hit);
    bool ButtonRecognition(RaycastHit hit)
    {
        if (hit.collider.name.Contains("LB") || hit.collider.name.Contains("RB"))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    bool ClothesRecognition(RaycastHit hit)
    {
        if (hit.collider.gameObject.GetComponentInParent<Transform>().parent.gameObject.name.Contains("Clothes"))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public void PrevButton()
    {
        SystemManager.Instance.GetCurrentSceneMain<InGameSceneMain>().GotoTitleScene();
    }

}
