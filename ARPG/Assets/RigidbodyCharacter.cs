using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RigidbodyCharacter : MonoBehaviour
{
    #region Variables
    public float speed = 5.0f;
    public float jumpHeight = 2.0f;
    public float dashDistance = 5.0f;

    private Rigidbody rigidbody;

    private Vector3 inputDirection = Vector3.zero;

    #endregion Variables

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
