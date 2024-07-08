using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    // 애니메이터 컨트롤러의 전이 관계에서 설정한 번호에 맞춤니다 
    public const int ANI_IDLE = 0;
    public const int ANI_WALK = 1;
    public const int ANI_INTERACT = 2;

    Animator anim;
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    //애니메이션 번호를 입력 받아서 플레이어의 애니메이션을 해당되는 애니메이션으로 바꿔주는 함수 
    public void ChangeAni(int aniNumber)
    {
        anim.SetInteger("AniNumber", aniNumber);
    }
    // Update is called once per frame 
    void Update()
    {

    }
}
