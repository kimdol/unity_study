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

    // �ùٸ� ���� ã���� 1, �ƴϸ� 0
    public bool IsItCorrect()
    {
        // ���� ������ �������� ���� ����ó��
        GameObject go = SystemManager.Instance.GetCurrentSceneMain<InGameSceneMain>().Mel.CrashedObject();
        if (!go)
        {
            Debug.Log("Crashed Gameobject is none");
            return false;
        }
        // "Ÿ��Ʋ �̸�"�� "player�� �ε��� ������Ʈ �̸�"�� �� ��
        // ������ true, Ʋ���� false
        string text = SystemManager.Instance.GetCurrentSceneMain<InGameSceneMain>().JobNameTitle.GetComponent<TextMesh>().text;
        if (text.Contains(go.name))
        {
            if (!mAlreadyDone)
            {
                switch (text)
                {
                    case "Artist":
                    case "ȭ��":
                        Inventory.Instance.GenerateCache(Inventory.CollectionConstants.Artist, 1);
                        break;
                    case "Farmer":
                    case "���":
                        Inventory.Instance.GenerateCache(Inventory.CollectionConstants.Farmer, 1);
                        break;
                    case "Firefighter":
                    case "�ҹ��":
                        Inventory.Instance.GenerateCache(Inventory.CollectionConstants.Firefighter, 1);
                        break;
                    case "Carpenter":
                    case "���":
                        Inventory.Instance.GenerateCache(Inventory.CollectionConstants.Carpenter, 1);
                        break;
                    case "Hairdresser":
                    case "�̿��":
                        Inventory.Instance.GenerateCache(Inventory.CollectionConstants.Hairdresser, 1);
                        break;
                    case "Police":
                    case "����":
                        Inventory.Instance.GenerateCache(Inventory.CollectionConstants.Police, 1);
                        break;
                    case "Marine":
                    case "����":
                        Inventory.Instance.GenerateCache(Inventory.CollectionConstants.Marine, 1);
                        break;
                    case "Doctor":
                    case "�ǻ�":
                        Inventory.Instance.GenerateCache(Inventory.CollectionConstants.Doctor, 1);
                        break;
                    case "Cook":
                    case "�丮��":
                        Inventory.Instance.GenerateCache(Inventory.CollectionConstants.Cook, 1);
                        break;
                    case "Singer":
                    case "����":
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
