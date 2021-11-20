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

    // 한글 이름 찾기
    string KrName(string EnName)
    {
        string krName = null;

        switch (EnName)
        {
            case "Artist":
            case "화가":
                krName = "화가";
                break;
            case "Farmer":
            case "농부":
                krName = "농부";
                break;
            case "Firefighter":
            case "소방관":
                krName = "소방관";
                break;
            case "Carpenter":
            case "목수":
                krName = "목수";
                break;
            case "Hairdresser":
            case "미용사":
                krName = "미용사";
                break;
            case "Police":
            case "경찰":
                krName = "경찰";
                break;
            case "Marine":
            case "군인":
                krName = "군인";
                break;
            case "Doctor":
            case "의사":
                krName = "의사";
                break;
            case "Cook":
            case "요리사":
                krName = "요리사";
                break;
            case "Singer":
            case "가수":
                krName = "가수";
                break;
        }
        return krName;
    }
}
