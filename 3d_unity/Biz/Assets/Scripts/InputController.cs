using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour
{
    GameObject mTouchObj;
    Vector3 mMousePos = Vector3.zero;
    public bool mDragingFlag = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        DragAndDrop();
    }

    // �巡�� �� ���
    void DragAndDrop()
    { 
        // ��ġ �νĵǰ�, �� ��ġ�� ������Ʈ�̸�
        if (Input.GetMouseButton(0) && TouchIsObj(out mTouchObj))
        {
            // ��ġ�� �̲����� ������ ������Ʈ�� �i�ư���
            mMousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mMousePos.z = Cloth.ZPOS - 0.1f;
            mTouchObj.GetComponent<Cloth>().InputMoveVector(mMousePos);
            mDragingFlag = true;
        }
        else
        {
            mDragingFlag = false;
        }

    }
    // �� ��ġ�� ������Ʈ�̸� 1, �ƴϸ� 0
    bool TouchIsObj(out GameObject touchObj)
    {
        RaycastHit hit;
        Ray touchray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Physics.Raycast(touchray, out hit);

        if (hit.collider != null)
        {
            if (hit.collider.gameObject.GetComponentInParent<Transform>().parent.gameObject.name == "Clothes")
            {
                touchObj = hit.collider.gameObject;
                return true;
            }
        }

        touchObj = null;
        return false;
    }
}
