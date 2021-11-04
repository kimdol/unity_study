using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Actor
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

    [SerializeField]
    Transform mArmSkillTransform;

    [SerializeField]
    Transform FireTransform;

    [SerializeField]
    float BulletSpeed = 1;


    // arm
    Quaternion mMoveArm = Quaternion.identity;
    Vector3 mArmPos = Vector3.zero;
    Quaternion mMoveArmSkill = Quaternion.identity;
    Vector3 mArmPosSkill = Vector3.zero;
    // 공중부양
    float mDelta = 0.003f;
    float mLevitSpeed = 3.0f;

    protected override void UpdateActor()
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

        mArmSkillTransform.rotation = mMoveArmSkill;
        mArmSkillTransform.localPosition = mArmPosSkill;

    }
    public void ProcessArmInput(Vector3 moveAngle, Vector3 moveDirection, Vector3 skillAngle, Vector3 skillMoveDirection)
    {
        mMoveArm.eulerAngles = moveAngle;
        mArmPos = moveDirection;

        mMoveArmSkill.eulerAngles = skillAngle;
        mArmPosSkill = skillMoveDirection;
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
        if (!enemy.IsDead)
        {
            enemy.OnCrash(this, CrashDamage);
        }
    }
    public override void OnCrash(Actor attacker, int damage)
    {
        base.OnCrash(attacker, damage);
    }

    public void Fire()
    {
        Bullet bullet = SystemManager.Instance.BulletManager.Generate(BulletManager.PlayerBulletIndex);
        bullet.Fire(OwnerSide.Player, FireTransform.position, FireTransform.right + FireTransform.up, BulletSpeed, Damage);
    }

}
