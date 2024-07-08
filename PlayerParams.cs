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

        //초기화 할때 헤드업 디스플레이에 플레이어의 이름과 기타 정보들이 제대로 표시되도록함
        DBookUIManager.instance.UpdatePlayerUI(this);
    }

    public void AddMoney(int money)
    {
        this.money += money;
        DBookUIManager.instance.UpdatePlayerUI(this);
    }
}
