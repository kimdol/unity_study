using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clothes : MonoBehaviour
{
    [SerializeField]
    Transform mRoomStandardTr;

    Vector3 mRoomStandardPos;
    // 파일 경로
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

    // 제자리 정렬
    void RoomSort()
    {
        Cloth[] allChildren = GetComponentsInChildren<Cloth>();

        foreach (Cloth child in allChildren)
        {
            Vector3 roomPos = mRoomStandardPos;
            switch (child.name)
            {
                case "Artist":
                case "화가":
                case "Farmer":
                case "농부":
                    child.SlowMoveVector(roomPos);
                    break;
                case "Firefighter":
                case "소방관":
                case "Carpenter":
                case "목수":
                    roomPos.x += 2.5f;
                    child.SlowMoveVector(roomPos);
                    break;
                case "Hairdresser":
                case "미용사":
                case "Police":
                case "경찰":
                    roomPos.x += 5.0f;
                    child.SlowMoveVector(roomPos);
                    break;
                case "Marine":
                case "군인":
                case "Doctor":
                case "의사":
                    roomPos.y -= 2.89f;
                    child.SlowMoveVector(roomPos);
                    break;
                case "Cook":
                case "요리사":
                    roomPos.y -= 2.89f;
                    roomPos.x += 2.5f;
                    child.SlowMoveVector(roomPos);
                    break;
                case "Singer":
                case "가수":
                    roomPos.y -= 2.89f;
                    roomPos.x += 5.0f;
                    child.SlowMoveVector(roomPos);
                    break;
            }
        }
    }
}
