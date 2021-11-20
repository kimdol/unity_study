using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePointAccumulator : MonoBehaviour
{
    [SerializeField]
    GameObject CompleteBotton;
    private bool mComplete = false;
    public bool Complete
    {
        get
        {
            return mComplete;
        }
    }

    private bool mMissionClear = false;
    private bool mAlreadyDone = false;

    private bool mClothesToMelIsEnd = false;
    public bool ClothesToMelIsEnd
    {
        get
        {
            return mClothesToMelIsEnd;
        }
        set
        {
            mClothesToMelIsEnd = value;
        }
    }
    private string mRecentlyCloth = null;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (SystemManager.Instance.GetCurrentSceneMain<InGameSceneMain>().Mel.IsCrash)
        {
            ClothesToMel();
        }
    }

    // 올바른 답을 찾으면 1, 아니면 0
    public bool IsItCorrect()
    {
        // 밑의 동작의 수월함을 위한 예외처리
        GameObject go = SystemManager.Instance.GetCurrentSceneMain<InGameSceneMain>().Mel.CrashedObject();
        if (!go)
        {
            Debug.Log("Crashed Gameobject is none");
            return false;
        }
        // "타이틀 이름"과 "player와 부딪힌 오브젝트 이름"을 비교 후
        // 맞으면 true, 틀리면 false
        string text = SystemManager.Instance.GetCurrentSceneMain<InGameSceneMain>().JobNameTitle.GetComponent<TextMesh>().text;
        if (text.Contains(go.name))
        {
            if (!mAlreadyDone)
            {
                switch (text)
                {
                    case "Artist":
                    case "화가":
                        Inventory.Instance.GenerateCache(Inventory.CollectionConstants.Artist, 1);
                        break;
                    case "Farmer":
                    case "농부":
                        Inventory.Instance.GenerateCache(Inventory.CollectionConstants.Farmer, 1);
                        break;
                    case "Firefighter":
                    case "소방관":
                        Inventory.Instance.GenerateCache(Inventory.CollectionConstants.Firefighter, 1);
                        break;
                    case "Carpenter":
                    case "목수":
                        Inventory.Instance.GenerateCache(Inventory.CollectionConstants.Carpenter, 1);
                        break;
                    case "Hairdresser":
                    case "미용사":
                        Inventory.Instance.GenerateCache(Inventory.CollectionConstants.Hairdresser, 1);
                        break;
                    case "Police":
                    case "경찰":
                        Inventory.Instance.GenerateCache(Inventory.CollectionConstants.Police, 1);
                        break;
                    case "Marine":
                    case "군인":
                        Inventory.Instance.GenerateCache(Inventory.CollectionConstants.Marine, 1);
                        break;
                    case "Doctor":
                    case "의사":
                        Inventory.Instance.GenerateCache(Inventory.CollectionConstants.Doctor, 1);
                        break;
                    case "Cook":
                    case "요리사":
                        Inventory.Instance.GenerateCache(Inventory.CollectionConstants.Cook, 1);
                        break;
                    case "Singer":
                    case "가수":
                        Inventory.Instance.GenerateCache(Inventory.CollectionConstants.Singer, 1);
                        break;
                }
                mAlreadyDone = true;
            }  
            return true;
        }
        else
        {
            return false;
        }
    }
    public void SuccessOrNot(bool success)
    {
        if (success)
        {
            mMissionClear = true;
        }
        else
        {
            mMissionClear = false;
        }
    }
    public void OnCompleteButton()
    {
        Inventory.Instance.Prepare();
        mComplete = true;
        CompleteBotton.SetActive(false);
        GameEndPanel gameEndPanel = PanelManager.GetPanel(typeof(GameEndPanel)) as GameEndPanel;
        gameEndPanel.ShowGameEnd(mMissionClear);
    }
    // 해당 옷을 멜에게 주면 그 옷을 입어야 하는 룰
    private void ClothesToMel()
    {
        /*해당 옷이 멜에게 놓으면 그 옷을 확대후 입혀라*/
        // 함수를 반드시 1번 실행하게 끔 함
        if (!mClothesToMelIsEnd)
        {
            // 만약 입혀진 옷이 있을 때
            if (mRecentlyCloth != null)
            {
                // 입혀진 옷을 원래 크기로 만든 후 캐쉬로 반환
            }
            // 옷이 멜에게 부딪혔을때 옷의 이름을 가져와라
            mRecentlyCloth = SystemManager.Instance.GetCurrentSceneMain<InGameSceneMain>().Mel.CrashedObject().name;
            // 그 옷을 Item 캐쉬에서 꺼내와서 적절한 위치에 고정배치하라
            // 그 옷을 확대하라
            // 함수 종료 플래그 온
            mClothesToMelIsEnd = true;
        }
    }
}
