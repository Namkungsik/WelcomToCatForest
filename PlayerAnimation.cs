using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    // �ִϸ����� ��Ʈ�ѷ��� ���� ���迡�� ������ ��ȣ�� ����ϴ� 
    public const int ANI_IDLE = 0;
    public const int ANI_WALK = 1;
    public const int ANI_INTERACT = 2;

    Animator anim;
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    //�ִϸ��̼� ��ȣ�� �Է� �޾Ƽ� �÷��̾��� �ִϸ��̼��� �ش�Ǵ� �ִϸ��̼����� �ٲ��ִ� �Լ� 
    public void ChangeAni(int aniNumber)
    {
        anim.SetInteger("AniNumber", aniNumber);
    }
    // Update is called once per frame 
    void Update()
    {

    }
}
