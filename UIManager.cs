using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    // ���� ��𼭳� ���� �����Ҽ� �ֵ��� �ϱ����� ���� ��������
    public static UIManager instance;

    public Text playerName;
    public Text playerMoney;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    public void UpdatePlayerUI(PlayerParams playerParams)
    {
        playerName.text = playerParams.name;
        playerMoney.text = "Money : " + playerParams.money.ToString();

    }
    void Update()
    {

    }
}
