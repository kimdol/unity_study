using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clothes : MonoBehaviour
{
    [SerializeField]
    Transform mRoomStandardTr;

    Vector3 mRoomStandardPos;
    // ���� ���
    public string FilePath
    {
        get;
        set;
    }
    // Start is called before the first frame update
    void Start()
    {
        mRoomStandardPos = mRoomStandardTr.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (!SystemManager.Instance.InputController.mDragingFlag)
        {
            RoomSort();
        }
    }

    // ���ڸ� ����
    void RoomSort()
    {
        Cloth[] allChildren = GetComponentsInChildren<Cloth>();

        foreach (Cloth child in allChildren)
        {
            Vector3 roomPos = mRoomStandardPos;
            switch (child.name)
            {
                case "Farmer":
                    child.SlowMoveVector(roomPos);
                    break;
                case "Carpenter":
                    roomPos.x += 2.5f;
                    child.SlowMoveVector(roomPos);
                    break;
                case "Police":
                    roomPos.x += 5.0f;
                    child.SlowMoveVector(roomPos);
                    break;
                case "Doctor":
                    roomPos.y -= 2.89f;
                    child.SlowMoveVector(roomPos);
                    break;
                case "Cook":
                    roomPos.y -= 2.89f;
                    roomPos.x += 2.5f;
                    child.SlowMoveVector(roomPos);
                    break;
                case "Singer":
                    roomPos.y -= 2.89f;
                    roomPos.x += 5.0f;
                    child.SlowMoveVector(roomPos);
                    break;
            }
        }
    }
}
