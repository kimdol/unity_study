using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePointAccumulator : MonoBehaviour
{
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
        if (SystemManager.Instance.GetCurrentSceneMain<InGameSceneMain>().JobNameTitle.GetComponent<TextMesh>().text.Contains(go.name))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
