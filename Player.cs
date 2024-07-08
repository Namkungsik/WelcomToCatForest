using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public enum State
    {
        Idle,
        Move,
        Interact
    }
    //idle 상태를 기본 상태로 지정 
    public State currentState = State.Idle;

    //마우수 클릭 지점,플레이어가 이동할 목적지의 좌표를 저장할 예정
    Vector3 curTargetPos;
    public float rotAnglePerSecond = 360f; //1초에 플레이어의 방향을 360도 회전한다
    public float moveSpeed = 2f; //초당 2미터의 속도로 이동

    GameObject obj;

    float InteractDistance = 0.5f; // 상호작용 거리

    PlayerAnimation myAni;
    TextMesh txtMesh;

    private int rndNum;
    private float FishingTime = 5f;

    private bool DBookActivated = false;

    void Start()
    {
        myAni = GetComponent<PlayerAnimation>();
        txtMesh = GetComponentInChildren<TextMesh>();
        ChangeState(State.Idle, PlayerAnimation.ANI_IDLE);
    }

    public void InteractObj(GameObject Object)
    {
        if (obj != null && obj == Object)
        {
            return;
        }

        obj = Object;
        curTargetPos = obj.transform.position;

        ChangeState(State.Move, PlayerAnimation.ANI_WALK);
    }

    void ChangeState(State newState, int aniNumber)
    {
        if (currentState == newState)
        {
            return;
        }

        myAni.ChangeAni(aniNumber);
        currentState = newState;
    }

    //캐릭터의 상태가 바뀌면 어떤 일이 일어날지를 미리 정의 
    void UpdateState()
    {
        switch (currentState)
        {
            case State.Idle:
                IdleState();
                break;
            case State.Move:
                MoveState();
                break;
            case State.Interact:
                InteractState();
                break;
            default:
                break;
        }
    }

    void IdleState()
    {
        txtMesh.text = "";
        DBookUIManager.instance.CloseBuyingHousePanel();
    }

    void MoveState()
    {
        TurnToDestination();
        MoveToDestination();
        txtMesh.text = "";
        DBookUIManager.instance.CloseBuyingHousePanel();
    }

    void InteractState()
    {
        transform.LookAt(curTargetPos);
        ChangeState(State.Interact, PlayerAnimation.ANI_INTERACT);
        txtMesh.text = obj.name;
        if(txtMesh.text == "Fishing")
        {
            Fishing();
        }
        else if(txtMesh.text == "Sign Post")
        {
            DBookUIManager.instance.OpenBuyingHousePanel();
        }
    }

    void Fishing()
    {
        if (FishingTime > 0)
        {
            FishingTime -= Time.deltaTime;
        }

        if (FishingTime <= 0)
        {
            rndNum = Random.Range(0, 10);
            FishingUIManager.instance.UpdatePlayerUI(rndNum);
            FishingTime = 5f;
        }
    }

    //MoveTo(캐릭터가 이동할 목표 지점의 좌표)
    public void MoveTo(Vector3 tPos)
    {
        obj = null;
        curTargetPos = tPos;
        ChangeState(State.Move, PlayerAnimation.ANI_WALK);
    }

    void TurnToDestination()
    {
        // Quaternion lookRotation(회전할 목표 방향) : 목표 방향은 목적지 위치에서 자신의 위치를 빼면 구함
        Quaternion lookRotation = Quaternion.LookRotation(curTargetPos - transform.position);

        //Quaternion.RotateTowards(현재의 rotation값, 최종목표rotation 값, 최대 회전각)
        transform.rotation = Quaternion.RotateTowards(transform.rotation, lookRotation, Time.deltaTime * rotAnglePerSecond);
    }

    void MoveToDestination()
    {
        //Vector3.MoveTowards(시작지점, 목표지점,최대이동거리)
        transform.position = Vector3.MoveTowards(transform.position, curTargetPos, moveSpeed * Time.deltaTime);


        if (obj == null)
        {
            //플레이어의 위치와 목표지점의 위치가 같으면, 상태를 Idle 상태로 바꾸라는 명령
            if (transform.position == curTargetPos)
            {
                ChangeState(State.Idle, PlayerAnimation.ANI_IDLE);
            }
        }
        else if (Vector3.Distance(transform.position, curTargetPos) < InteractDistance)
        {
            ChangeState(State.Interact, PlayerAnimation.ANI_INTERACT);
        }
    }

    // Update is called once per frame 
    void Update()
    {
        UpdateState();

        if (Input.GetKeyDown(KeyCode.A))
        {
            DBookActivated = !DBookActivated;

            if (DBookActivated)
                DBookUIManager.instance.OpenDBookUI();
            else
                DBookUIManager.instance.CloseDBookUI();

        }
    }
}
