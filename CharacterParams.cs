using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterParams : MonoBehaviour
{
    public int level { get; set; }

    void Start()
    {
        InitParams();
    }

    //나중에 CharacterParams 클래스를 상속한 자식클래스 에서 
    //InitParams 함수 에 자신만의 명령어를 추가하기만 하면 자동으로 필요한 명령어드이 실행
    public virtual void InitParams()
    {

    }
}
