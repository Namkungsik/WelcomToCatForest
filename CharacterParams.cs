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

    //���߿� CharacterParams Ŭ������ ����� �ڽ�Ŭ���� ���� 
    //InitParams �Լ� �� �ڽŸ��� ��ɾ �߰��ϱ⸸ �ϸ� �ڵ����� �ʿ��� ��ɾ���� ����
    public virtual void InitParams()
    {

    }
}
