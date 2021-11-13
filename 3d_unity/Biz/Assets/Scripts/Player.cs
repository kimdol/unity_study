using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    GameObject mCrashedObject = null;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    // ���� ���ϸ� ���信 ���� ǥ�� ��ȭ��
    private void OnTriggerEnter(Collider other)
    {
        // CrashedObject�Լ��� ���� �ڵ� �� ��
        mCrashedObject = other.gameObject;

        transform.GetChild(0).gameObject.SetActive(true);                   // ���� ǥ��
        transform.GetChild(1).gameObject.SetActive(false);
        transform.GetChild(2).gameObject.SetActive(false);

        if (SystemManager.Instance.GetCurrentSceneMain<InGameSceneMain>().GamePointAccumulator.IsItCorrect())      // ������ ��� ����
        {
            transform.GetChild(0).gameObject.SetActive(false);
            transform.GetChild(1).gameObject.SetActive(true);
            SystemManager.Instance.GetCurrentSceneMain<InGameSceneMain>().GamePointAccumulator.SuccessOrNot(true);
        }
        else                                                                // ������ ��� ���׸�
        {
            transform.GetChild(0).gameObject.SetActive(false);
            transform.GetChild(2).gameObject.SetActive(true);
            SystemManager.Instance.GetCurrentSceneMain<InGameSceneMain>().GamePointAccumulator.SuccessOrNot(false);
        }
    }
    // ���� �ε��� ���� ������Ʈ�� ��ȯ��
    public GameObject CrashedObject()
    {
        // �ε��� ���� ������Ʈ�� ������
        GameObject go = mCrashedObject;
        mCrashedObject = null;
        // �� ������Ʈ�� ������
        return go;
        
    }
}
