using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    [SerializeField]
    PrefabCacheData[] ItemFiles;

    Dictionary<string, GameObject> FileCache = new Dictionary<string, GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        Prepare();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public GameObject GenerateItem(int index, Vector3 position)
    {
        if (index < 0 || index >= ItemFiles.Length)
        {
            Debug.LogError("GenerateEffect error! out of range! index = " + index);
            return null;
        }

        string filePath = ItemFiles[index].filePath;
        GameObject go = SystemManager.Instance.GetCurrentSceneMain<InGameSceneMain>().ItemCacheSystem.Archive(filePath);

        Item item = go.GetComponent<Item>();
        item.FilePath = filePath;

        return go;
    }

    public GameObject Load(string resourcePath)
    {
        GameObject go = null;

        if (FileCache.ContainsKey(resourcePath))   // ĳ�� Ȯ��
        {
            go = FileCache[resourcePath];
        }
        else
        {
            // ĳ�ÿ� �����Ƿ� �ε�
            go = Resources.Load<GameObject>(resourcePath);
            if (!go)
            {
                Debug.LogError("Load error! path = " + resourcePath);
                return null;
            }
            // �ε� �� ĳ�ÿ� ����
            FileCache.Add(resourcePath, go);
        }

        return go;
    }
    public void Prepare()
    {
        for (int i = 0; i < ItemFiles.Length; i++)
        {
            GameObject go = Load(ItemFiles[i].filePath);
            SystemManager.Instance.GetCurrentSceneMain<InGameSceneMain>().ItemCacheSystem.GenerateCache(ItemFiles[i].filePath, go, ItemFiles[i].cacheCount);
        }
    }
    public bool RemoveItem(Item item)
    {
        SystemManager.Instance.GetCurrentSceneMain<InGameSceneMain>().ItemCacheSystem.Restore(item.FilePath, item.gameObject);
        return true;
    }
    // �������̸��� index�� �ٲٱ�(���н� -1)
    public int ItemNameToIndex(string name)
    {
        switch (name)
        {
            case "Artist":
            case "ȭ��":
                return 0;
            case "ȭ������":
                return 1;
            case "Farmer":
            case "���":
                return 8;
            case "��ε���":
                return 9;
            case "Firefighter":
            case "�ҹ��":
                return 10;
            case "�ҹ������":
                return 11;
            case "Carpenter":
            case "���":
                return 2;
            case "�������":
                return 3;
            case "Hairdresser":
            case "�̿��":
                return 12;
            case "�̿�絵��":
                return 13;
            case "Police":
            case "����":
                return 16;
            case "��������":
                return 17;
            case "Marine":
            case "����":
                return 14;
            case "���ε���":
                return 15;
            case "Doctor":
            case "�ǻ�":
                return 6;
            case "�ǻ絵��":
                return 7;
            case "Cook":
            case "�丮��":
                return 4;
            case "�丮�絵��":
                return 5;
            case "Singer":
            case "����":
                return 18;
            case "��������":
                return 19;
        }
        return -1;
    }
}
