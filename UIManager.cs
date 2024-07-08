using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    // 언제 어디서나 쉽게 접금할수 있도록 하기위해 만든 정적변수
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
