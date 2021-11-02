using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Actor
{
    public enum State : int
    {
        None = -1,      // 사용전
        Ready = 0,      // 준비 완료
        Appear,         // 등장
        Battle,         // 전투중
        Destruction,    // 파괴
        Dead,           // 사망
        Disappear       // 퇴장
    }

    [SerializeField]
    State CurrentState = State.None;

    const float MaxSpeed = 10.0f;

    const float MaxSpeedTime = 0.5f;

    [SerializeField]
    Vector3 TargetPosition;

    [SerializeField]
    float CurrentSpeed;


    Vector3 CurrentVelocity;

    float MoveStartTime = 0.0f;

    float BattleStateTime = 0.0f;

    [SerializeField]
    int GamePoint = 1;

    protected override void UpdateActor()
    {
        switch (CurrentState)
        {
            case State.None:
            case State.Ready:
                break;
            case State.Dead:
                break;
            case State.Appear:
            case State.Disappear:
                UpdateSpeed();
                UpdateMove();
                break;
            case State.Battle:
                UpdateBattle();
                break;

        }
    }

    void UpdateSpeed()
    {
        CurrentSpeed = Mathf.Lerp(CurrentSpeed, MaxSpeed, (Time.time - MoveStartTime) / MaxSpeedTime);
    }
    void UpdateMove()
    {
        // 파괴 상태
        if (CurrentState == State.Destruction)
        {
            transform.position = TargetPosition;
        }
        float distance = Vector3.Distance(TargetPosition, transform.position);
        if (distance == 0)
        {
            Arrived();
            return;
        }
        // 나타남 상태
        CurrentVelocity = (TargetPosition - transform.position).normalized * CurrentSpeed;
        transform.position = Vector3.SmoothDamp(transform.position, TargetPosition, ref CurrentVelocity, (distance / CurrentSpeed), MaxSpeed);
    }
    void Arrived()
    {
        CurrentSpeed = 0.0f;
        if (CurrentState == State.Appear)
        {
            CurrentState = State.Battle;
            BattleStateTime = Time.time;
        }
        else if (CurrentState == State.Disappear)
        {
            CurrentState = State.None;
        }
    }
    public void Appear(Vector3 targetPos)
    {
        TargetPosition = targetPos;
        CurrentSpeed = MaxSpeed;

        CurrentState = State.Appear;
        MoveStartTime = Time.time;
    }
    void Disappear(Vector3 targetPos)
    {
        TargetPosition = targetPos;
        CurrentSpeed = 0;

        CurrentState = State.Disappear;
        MoveStartTime = Time.time;
    }
    void MoveDestruction(Vector3 targetPos)
    {
        TargetPosition = targetPos;
        CurrentState = State.Disappear;
    }

    void UpdateBattle()
    {
        if(Time.time - BattleStateTime > 3.0f)
        {
            Disappear(new Vector3(transform.position.x, -11.01f, transform.position.z));
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Player player = other.GetComponentInParent<Player>();
    }
    public override void OnCrash(Actor attacker, int damage)
    {
        OnCrash(attacker, damage);
    }

    protected override void OnDead(Actor killer)
    {
        base.OnDead(killer);
        {
            base.OnDead(killer);
            SystemManager.Instance.GamePointAccumulator.Accumulate(GamePoint);
            CurrentState = State.Dead;
        }
    }
}
