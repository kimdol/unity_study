using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    Vector3 MoveVector = Vector3.zero;

    [SerializeField]
    float Speed;

    [SerializeField]
    BoxCollider boxCollider;

    [SerializeField]
    Transform MainBGQuadTransform;

    [SerializeField]
    Transform mArmTransform;
    // arm
    Quaternion mMoveArm = Quaternion.identity;
    Vector3 mAgle = Vector3.zero;
    Vector3 mArmPos = Vector3.zero;
    // 공중부양
    float mDelta = 0.0015f;
    float mLevitSpeed = 2.0f;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        UpdateMove();
        UpdateArm();
        Levitating();
    }
    // 캐릭터 움직이기
    void UpdateMove()
    {
        if (MoveVector.sqrMagnitude == 0)
        {
            return;
        }

        MoveVector = AdjustMoveVector(MoveVector);

        transform.position += MoveVector;
    }
    public void ProcessInput(Vector3 moveDirection)
    {
        MoveVector = moveDirection * Speed * Time.deltaTime;
    }
    Vector3 AdjustMoveVector(Vector3 moveVector)
    {
        Vector3 result = Vector3.zero;

        result = boxCollider.transform.position + boxCollider.center + moveVector;

        if (result.x - boxCollider.size.x * 0.5f < -MainBGQuadTransform.localScale.x * 0.5f)
        {
            moveVector.x = 0;
        }

        if (result.x + boxCollider.size.x * 0.5f > MainBGQuadTransform.localScale.x * 0.5f)
        {
            moveVector.x = 0;
        }

        if (result.y - boxCollider.size.y * 0.5f < -MainBGQuadTransform.localScale.y * 0.5f + 1)
        {
            moveVector.y = 0;
        }

        if (result.y + boxCollider.size.y * 0.5f > MainBGQuadTransform.localScale.y * 0.5f)
        {
            moveVector.y = 0;
        }

        return moveVector;
    }
    // 팔 움직이기
    void UpdateArm()
    {
        mArmTransform.rotation = mMoveArm;
        mArmTransform.localPosition = mArmPos;
    }
    public void ProcessArmInput(Vector3 moveAngle, Vector3 moveDirection)
    {
        mMoveArm.eulerAngles = moveAngle;
        mArmPos = moveDirection;
    }
    // 공중부양
    void Levitating()
    {
        Vector3 LevitMove = Vector3.zero;
        LevitMove.y += (mDelta * Mathf.Sin(Time.time * mLevitSpeed));
        transform.position += AdjustMoveVector(LevitMove);
    }

    private void OnTriggerEnter(Collider other)
    {
        Enemy enemy = other.GetComponentInParent<Enemy>();
        if (enemy)
        {
            enemy.OnCrash(this);
        }
    }
    public void OnCrash(Enemy enemy)
    {

    }
}
