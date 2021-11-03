using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        UpdateInput();
        UpdateMouse();
    }

    void UpdateInput()
    {
        Vector3 moveDirection = Vector3.zero;

        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            moveDirection.y = 1;
        }
        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            moveDirection.y = -1;
        }
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            moveDirection.x = -1;
        }
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            moveDirection.x = 1;
        }

        SystemManager.Instance.Hero.ProcessInput(moveDirection);

    }

    void UpdateMouse()
    {
        Vector3 moveDirectionArm = Vector3.zero; // rotation
        Vector3 moveDirectionArm2 = new Vector3(0.09f, 0.26f, -0.46f); // pos

        Vector3 moveArmSkill = new Vector3(33.51f, 90.0f, 0.0f);
        Vector3 moveArmSkill2 = new Vector3(0.39f, -0.06f, -3.22f);

        if (Input.GetMouseButton(0))
        {
            moveDirectionArm.z = 115.02f;
            moveDirectionArm2.Set(0.12f, 0.38f, -0.46f);

            moveArmSkill.Set(-30.04f, 90.0f, 0.0f);
            moveArmSkill2.Set(0.39f, 0.8f, -3.22f);
        }
        
        if (Input.GetMouseButtonDown(0))
        {
            SystemManager.Instance.Hero.Fire();
        }

        SystemManager.Instance.Hero.ProcessArmInput(moveDirectionArm, moveDirectionArm2,
            moveArmSkill, moveArmSkill2);
    }
}
