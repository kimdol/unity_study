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
        if (!SystemManager.Instance.GetCurrentSceneMain<InGameSceneMain>().InputController.DragingFlag)
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
                case "Artist":
                case "ȭ��":
                case "ȭ������":
                case "Farmer":
                case "���":
                case "��ε���":
                    child.SlowMoveVector(roomPos);
                    break;
                case "Firefighter":
                case "�ҹ��":
                case "�ҹ������":
                case "Carpenter":
                case "���":
                case "�������":
                    roomPos.x += 2.5f;
                    child.SlowMoveVector(roomPos);
                    break;
                case "Hairdresser":
                case "�̿��":
                case "�̿�絵��":
                case "Police":
                case "����":
                case "��������":
                    roomPos.x += 5.0f;
                    child.SlowMoveVector(roomPos);
                    break;
                case "Marine":
                case "����":
                case "���ε���":
                case "Doctor":
                case "�ǻ�":
                case "�ǻ絵��":
                    roomPos.y -= 2.89f;
                    child.SlowMoveVector(roomPos);
                    break;
                case "Cook":
                case "�丮��":
                case "�丮�絵��":
                    roomPos.y -= 2.89f;
                    roomPos.x += 2.5f;
                    child.SlowMoveVector(roomPos);
                    break;
                case "Singer":
                case "����":
                case "��������":
                    roomPos.y -= 2.89f;
                    roomPos.x += 5.0f;
                    child.SlowMoveVector(roomPos);
                    break;
            }
        }
    }
}
