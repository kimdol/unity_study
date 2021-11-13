using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectionManager : MonoBehaviour
{
    [SerializeField]
    PrefabCacheData[] CollectionFiles;

    Dictionary<string, GameObject> FileCache = new Dictionary<string, GameObject>();

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }

    public GameObject Generate(int index, Vector3 position)
    {

        if (index < 0 || index >= CollectionFiles.Length)
        {
            Debug.LogError("Generate error! out of range! index = " + index);
            return null;
        }

        string filePath = CollectionFiles[index].filePath;
        GameObject go = SystemManager.Instance.GetCurrentSceneMain<InGameSceneMain>().CollectionCacheSystem.Archive(filePath);
        go.transform.position = position;

        Collection collection = go.GetComponent<Collection>();
        collection.FilePath = filePath;

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
        for (int i = 0; i < CollectionFiles.Length; i++)
        {
            GameObject go = Load(CollectionFiles[i].filePath);
            SystemManager.Instance.GetCurrentSceneMain<InGameSceneMain>().CollectionCacheSystem.GenerateCache(CollectionFiles[i].filePath, go, CollectionFiles[i].cacheCount);
        }
    }

    public bool Remove(Collection collection)
    {
        SystemManager.Instance.GetCurrentSceneMain<InGameSceneMain>().CollectionCacheSystem.Restore(collection.FilePath, collection.gameObject);
        return true;
    }
}
