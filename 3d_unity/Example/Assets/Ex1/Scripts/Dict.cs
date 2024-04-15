using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dict : MonoBehaviour
{
    Dictionary<string, int> dict;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Dict Start");

        dict = new Dictionary<string, int>();

        foreach (var kvp in dict)
        {
            Debug.Log(kvp.Key + ", " + kvp.Value);
        }

        if (!dict.ContainsKey("a"))
        {
            dict["a"] = 1;
        }

        foreach(var kvp in dict)
        {
            Debug.Log(kvp.Key + ", " + kvp.Value);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
