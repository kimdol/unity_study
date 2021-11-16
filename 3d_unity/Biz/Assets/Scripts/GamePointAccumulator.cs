using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePointAccumulator : MonoBehaviour
{
    [SerializeField]
    GameObject CompleteBotton;

    private bool mComplete = false;
    private bool mAlreadyDone = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
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
            mComplete = true;
        }
        else
        {
            mComplete = false;
        }
    }
    public void OnCompleteButton()
    {
        Inventory.Instance.Prepare();
        CompleteBotton.SetActive(false);
        GameEndPanel gameEndPanel = PanelManager.GetPanel(typeof(GameEndPanel)) as GameEndPanel;
        gameEndPanel.ShowGameEnd(mComplete);
    }
}
