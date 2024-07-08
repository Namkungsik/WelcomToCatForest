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
    //idle ���¸� �⺻ ���·� ���� 
    public State currentState = State.Idle;

    //����� Ŭ�� ����,�÷��̾ �̵��� �������� ��ǥ�� ������ ����
    Vector3 curTargetPos;
    public float rotAnglePerSecond = 360f; //1�ʿ� �÷��̾��� ������ 360�� ȸ���Ѵ�
    public float moveSpeed = 2f; //�ʴ� 2������ �ӵ��� �̵�

    GameObject obj;

    float InteractDistance = 0.5f; // ��ȣ�ۿ� �Ÿ�

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

    //ĳ������ ���°� �ٲ�� � ���� �Ͼ���� �̸� ���� 
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

    //MoveTo(ĳ���Ͱ� �̵��� ��ǥ ������ ��ǥ)
    public void MoveTo(Vector3 tPos)
    {
        obj = null;
        curTargetPos = tPos;
        ChangeState(State.Move, PlayerAnimation.ANI_WALK);
    }

    void TurnToDestination()
    {
        // Quaternion lookRotation(ȸ���� ��ǥ ����) : ��ǥ ������ ������ ��ġ���� �ڽ��� ��ġ�� ���� ����
        Quaternion lookRotation = Quaternion.LookRotation(curTargetPos - transform.position);

        //Quaternion.RotateTowards(������ rotation��, ������ǥrotation ��, �ִ� ȸ����)
        transform.rotation = Quaternion.RotateTowards(transform.rotation, lookRotation, Time.deltaTime * rotAnglePerSecond);
    }

    void MoveToDestination()
    {
        //Vector3.MoveTowards(��������, ��ǥ����,�ִ��̵��Ÿ�)
        transform.position = Vector3.MoveTowards(transform.position, curTargetPos, moveSpeed * Time.deltaTime);


        if (obj == null)
        {
            //�÷��̾��� ��ġ�� ��ǥ������ ��ġ�� ������, ���¸� Idle ���·� �ٲٶ�� ���
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
