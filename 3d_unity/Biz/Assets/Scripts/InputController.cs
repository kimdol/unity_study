using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour
{
    const float DRAGCRITERION = 1.0f;
    GameObject mTouchObj;
    Vector3 mMousePos = Vector3.zero;
    public bool mDragingFlag = false;

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

    // 드래그 앤 드롭
    void DragAndDrop()
    { 
        // 터치 인식되고, 그 터치가 오브젝트이면
        if (Input.GetMouseButton(0) && TouchIsObj(out mTouchObj))
        {
            // 터치가 이끌리는 곳으로 오브젝트가 쫒아가라
            mMousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mMousePos.z = Cloth.ZPOS - DRAGCRITERION; // 드래그 판정 조절
            mTouchObj.GetComponent<Cloth>().InputMoveVector(mMousePos);
            mDragingFlag = true;
            
        }
        else
        {
            mDragingFlag = false;
        }

    }
    // 그 터치가 오브젝트이면 1, 아니면 0(드래그 앤 드롭전용)
    bool TouchIsObj(out GameObject touchObj)
    {
        RaycastHit hit;
        Ray touchray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Physics.Raycast(touchray, out hit);

        if (hit.collider != null)
        {
            if (hit.collider.gameObject.GetComponentInParent<Transform>().parent.gameObject.name.Contains("Clothes"))
            {
                touchObj = hit.collider.gameObject;
                return true;
            }
        }

        touchObj = null;
        return false;
    }
    
    // 버튼 클릭 시 이벤트 발생
    void ButtonClick()
    {
        if (Input.GetMouseButtonDown(0) && ClickIsButton(out mClickButtonObj))
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
    bool ClickIsButton(out GameObject touchObj)
    {
        RaycastHit hit;
        Ray touchray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Physics.Raycast(touchray, out hit);

        if (hit.collider != null)
        {
            if (hit.collider.name.Contains("LB") || hit.collider.name.Contains("RB"))
            {
                touchObj = hit.collider.gameObject;
                return true;
            }
        }

        touchObj = null;
        return false;
    }
}
