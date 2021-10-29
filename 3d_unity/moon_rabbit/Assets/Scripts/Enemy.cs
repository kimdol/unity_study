using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public enum State
    {
        None = -1,  // 사용전
        Ready = 0,  // 준비 완료
        Appear,     // 등장
        Battle,     // 전투중
        Dead,       // 파괴
        Disappear   // 퇴장
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


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            Appear(new Vector3(-0.73f, -4.35f, 0.0f));
        }

        if (Input.GetKeyDown(KeyCode.K))
        {
            Destruction(new Vector3(-0.73f, -10.52f, 0.0f));
        }
        if (CurrentState == State.Appear || CurrentState == State.Disappear)
        {
            UpdateSpeed();
            UpdateMove();
        }
    }

    void UpdateSpeed()
    {
        CurrentSpeed = Mathf.Lerp(CurrentSpeed, MaxSpeed, (Time.time - MoveStartTime) / MaxSpeedTime);
    }
    void UpdateMove()
    {
        // 파괴 상태
        if (CurrentState == State.Disappear)
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
    void Destruction(Vector3 targetPos)
    {
        TargetPosition = targetPos;
        CurrentState = State.Disappear;
    }
}
