using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    // 접근 당하면 정답에 따라서 표정 변화함
    private void OnTriggerEnter(Collider other)
    {
        // 정답일 경우 웃음
        // 오답일 경우 찡그림
    }
}
