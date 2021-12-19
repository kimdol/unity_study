using System.Collections;   // 컨테이너
using System.Collections.Generic;
using UnityEngine;

public class MyScript : MonoBehaviour
{
    public float speed = 5.0f;

    // Start is called before the first frame update
    void Start()
    {
        Vector3 v = new Vector3(0, 0, 0);
        Function(v);
        Debug.Log(v);
    }

    // call by value
    void Function(Vector3 v)
    {
        v.x = 10;
        v.y = 10;
        v.z = 10;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(Time.time);
        Vector3 pos = transform.position;
        pos.x = Mathf.Sin(Time.time * speed);
        transform.position = pos;
    }
}
