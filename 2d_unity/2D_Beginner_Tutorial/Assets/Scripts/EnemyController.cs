using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float speed;
    public float changeTime = 3.0f;

    Rigidbody2D rigidbody2D;

    float timer;
    public int direction = 1;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();

        timer = changeTime;
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        Debug.Log(timer);



        Vector2 position = rigidbody2D.position;
        position.x = position.x + Time.deltaTime * speed * direction;

        rigidbody2D.MovePosition(position);  // 실제 이동

    }
}
