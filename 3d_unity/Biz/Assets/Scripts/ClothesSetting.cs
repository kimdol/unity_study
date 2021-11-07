using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClothesSetting : MonoBehaviour
{
    bool a = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (a)
        {
            Setting();
            a = false;
        }
        
    }

    // ¿Êµé ¼¼ÆÃ
    public void Setting()
    {
        SystemManager.Instance.ClothesManager.GenerateClothes(SystemManager.Instance.ClothesManager.Clothes01Index, new Vector3(0, 0, 0));
    }
}
