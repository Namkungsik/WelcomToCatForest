using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerParams : CharacterParams
{
    public string name { get; set; }
    public int curExp { get; set; }
    public int expToNextLevel { get; set; }
    public int money { get; set; }

    public override void InitParams()
    {
        name = "NAVI";
        money = 0;

        //�ʱ�ȭ �Ҷ� ���� ���÷��̿� �÷��̾��� �̸��� ��Ÿ �������� ����� ǥ�õǵ�����
        DBookUIManager.instance.UpdatePlayerUI(this);
    }

    public void AddMoney(int money)
    {
        this.money += money;
        DBookUIManager.instance.UpdatePlayerUI(this);
    }
}
