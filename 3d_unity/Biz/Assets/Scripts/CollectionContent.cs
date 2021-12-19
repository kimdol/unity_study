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
                krName = "ȭ��";
                break;
            case "Farmer":
                krName = "���";
                break;
            case "Firefighter":
                krName = "�ҹ��";
                break;
            case "Carpenter":
                krName = "���";
                break;
            case "Hairdresser":
                krName = "�̿��";
                break;
            case "Police":
                krName = "����";
                break;
            case "Marine":
                krName = "����";
                break;
            case "Doctor":
                krName = "�ǻ�";
                break;
            case "Cook":
                krName = "�丮��";
                break;
            case "Singer":
                krName = "����";
                break;
        }
        return krName;
    }
}
