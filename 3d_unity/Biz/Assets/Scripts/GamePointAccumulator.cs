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

    private CollectionFilePath mCollectionName = null;
    private bool mClothMission = false;
    private bool mToolMission = false;
    private bool mMissionClear = false;
    // private bool mAlreadyDone = false;

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
    private string mRecentlyClothName = null;
    private GameObject mRecentlyCloth = null;
    private string mRecentlyToolName = null;
    private GameObject mRecentlyTool = null;

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

    // �ùٸ� ���� ã���� 1, �ƴϸ� 0
    public bool IsItCorrect(out string whatmission)
    {
        // ���� ������ �������� ���� ����ó��
        GameObject go = SystemManager.Instance.GetCurrentSceneMain<InGameSceneMain>().Mel.CrashedObject();
        if (!go)
        {
            Debug.Log("Crashed Gameobject is none");
            whatmission = null;
            return false;
        }
        // "Ÿ��Ʋ �̸�"�� "player�� �ε��� ������Ʈ �̸�"�� �� ��
        // ������ true, Ʋ���� false
        string text = SystemManager.Instance.GetCurrentSceneMain<InGameSceneMain>().JobNameTitle.GetComponent<TextMesh>().text;
        if (go.name.Contains(text))
        {
            switch (text)
            {
                case "Artist":
                case "ȭ��":
                    mCollectionName = Inventory.CollectionConstants.Artist;
                    break;
                case "Farmer":
                case "���":
                    mCollectionName = Inventory.CollectionConstants.Farmer;
                    break;
                case "Firefighter":
                case "�ҹ��":
                    mCollectionName = Inventory.CollectionConstants.Firefighter;
                    break;
                case "Carpenter":
                case "���":
                    mCollectionName = Inventory.CollectionConstants.Carpenter;
                    break;
                case "Hairdresser":
                case "�̿��":
                    mCollectionName = Inventory.CollectionConstants.Hairdresser;
                    break;
                case "Police":
                case "����":
                    mCollectionName = Inventory.CollectionConstants.Police;
                    break;
                case "Marine":
                case "����":
                    mCollectionName = Inventory.CollectionConstants.Marine;
                    break;
                case "Doctor":
                case "�ǻ�":
                    mCollectionName = Inventory.CollectionConstants.Doctor;
                    break;
                case "Cook":
                case "�丮��":
                    mCollectionName = Inventory.CollectionConstants.Cook;
                    break;
                case "Singer":
                case "����":
                    mCollectionName = Inventory.CollectionConstants.Singer;
                    break;
            }
            if (go.name.Contains("����"))
            {
                whatmission = "tool";
            }
            else
            {
                whatmission = "cloth";
            }
            return true;
        }
        else
        {
            whatmission = null;
            return false;
        }
    }
    public void SuccessOrNot(bool success, string mission)
    {
        if ((mission == "tool") && (success == true))
        {
            mToolMission = true;
        }
        else if ((mission == "cloth") && (success == true))
        {
            mClothMission = true;
        }

        if (mToolMission && mClothMission)
        {
            Inventory.Instance.GenerateCache(mCollectionName, 1);
            mMissionClear = true;
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
    // �ش� ���� �ῡ�� �ָ� �� ���� �Ծ�� �ϴ� ��
    private void ClothesToMel()
    {
        /*�ش� ���� �ῡ�� ������ �� ���� Ȯ���� ������*/
        // �Լ��� �ݵ�� 1�� �����ϰ� �� ��
        if (!mClothesToMelIsEnd)
        {
            // ���� �ῡ�� �ε������� ���� �̸��� �����Ͷ�
            mRecentlyClothName = SystemManager.Instance.GetCurrentSceneMain<InGameSceneMain>().Mel.CrashedObject().name;

            // ���� ������ ���� ���� ��
            if ((mRecentlyCloth != null) && (!mRecentlyClothName.Contains("����")))
            {
                // ������ ���� ���� ũ��� ���� �� ĳ���� ��ȯ
                SystemManager.Instance.GetCurrentSceneMain<InGameSceneMain>().ItemManager.RemoveItem(mRecentlyCloth.GetComponent<Item>());
            }
            // ���� ������ ������ ���� ��
            if ((mRecentlyTool != null) && (mRecentlyClothName.Contains("����")))
            {
                // ������ ���� ���� ũ��� ���� �� ĳ���� ��ȯ
                SystemManager.Instance.GetCurrentSceneMain<InGameSceneMain>().ItemManager.RemoveItem(mRecentlyTool.GetComponent<Item>());
            }

            // �� ���� Item ĳ������ �����ͼ� ������ ��ġ�� ������ġ�϶�
            ItemManager itmmng = SystemManager.Instance.GetCurrentSceneMain<InGameSceneMain>().ItemManager;
            if (mRecentlyClothName.Contains("����"))
            {
                mRecentlyToolName = mRecentlyClothName;
                mRecentlyClothName = null;
                mRecentlyTool = itmmng.GenerateItem(itmmng.ItemNameToIndex(mRecentlyToolName), new Vector3(-5.52f, -0.66f, 19.5f));
                // �Լ� ���� �÷��� ��
                mClothesToMelIsEnd = true;

                return;
            }
            mRecentlyCloth = itmmng.GenerateItem(itmmng.ItemNameToIndex(mRecentlyClothName), new Vector3(-5.52f, -0.66f, 19.5f));
            // �Լ� ���� �÷��� ��
            mClothesToMelIsEnd = true;
        }
    }
}
