using System.Collections;   // 컨테이너
using System.Collections.Generic;
using UnityEngine;

public class MyScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Hellow World!");
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(Time.time);
        Vector3 pos = transform.position;
        pos.x = Mathf.Sin(Time.time * 5.0f);
        transform.position = pos;
    }
}
