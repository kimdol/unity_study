using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CollectionContent : MonoBehaviour
{
    private void Awake()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).transform.GetChild(0).gameObject.SetActive(false);
            transform.GetChild(i).transform.GetChild(2).gameObject.SetActive(false);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        List<Sprite> sp = Inventory.Instance.GetAllSprite();

        for (int i = 0; i < transform.childCount; i++)
        {
            if (sp.Count != i)
            {
                transform.GetChild(i).transform.GetChild(0).gameObject.SetActive(true);
                transform.GetChild(i).transform.GetChild(1).gameObject.SetActive(false);
                transform.GetChild(i).transform.GetChild(2).gameObject.SetActive(true);
                transform.GetChild(i).transform.GetChild(3).GetComponent<Text>().text = KrName(sp[i].name);
                transform.GetChild(i).GetComponent<Image>().sprite = sp[i];
            }
            else
            {
                break;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    // �ѱ� �̸� ã��
    string KrName(string EnName)
    {
        string krName = null;

        switch (EnName)
        {
            case "Artist":
            case "ȭ��":
                krName = "ȭ��";
                break;
            case "Farmer":
            case "���":
                krName = "���";
                break;
            case "Firefighter":
            case "�ҹ��":
                krName = "�ҹ��";
                break;
            case "Carpenter":
            case "���":
                krName = "���";
                break;
            case "Hairdresser":
            case "�̿��":
                krName = "�̿��";
                break;
            case "Police":
            case "����":
                krName = "����";
                break;
            case "Marine":
            case "����":
                krName = "����";
                break;
            case "Doctor":
            case "�ǻ�":
                krName = "�ǻ�";
                break;
            case "Cook":
            case "�丮��":
                krName = "�丮��";
                break;
            case "Singer":
            case "����":
                krName = "����";
                break;
        }
        return krName;
    }
}
