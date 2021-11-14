using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RecentlyCollection : MonoBehaviour
{
    Sprite sprite;

    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<Image>().sprite = Inventory.Instance.GetSprite(Inventory.Instance.RecentlyCollection.imageFilePath);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
