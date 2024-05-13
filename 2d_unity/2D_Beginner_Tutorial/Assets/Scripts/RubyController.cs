using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Searcher.SearcherWindow.Alignment;

public class RubyController : MonoBehaviour
{
    Rigidbody2D rigidbody2d;

    public float speed;

    public int maxHealth = 5;
    
    int currentHealth;
    public int health { get { return currentHealth; } }


    // Start is called before the first frame update
    void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();

        currentHealth = maxHealth;

        ChangeHealth(-1);
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector2 position = rigidbody2d.position;
        position.x = position.x + speed * Time.deltaTime * horizontal;
        position.y = position.y + speed * Time.deltaTime * vertical;

        
        rigidbody2d.MovePosition(position);




    }

    public void ChangeHealth(int amount)
    {
        currentHealth = Mathf.Clamp(currentHealth + amount, 0, maxHealth);
        Debug.Log(currentHealth + "/" + maxHealth);
    }
}
