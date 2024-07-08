using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DBookUIManager : MonoBehaviour
{
    // 언제 어디서나 쉽게 접금할수 있도록 하기위해 만든 정적변수
    public static DBookUIManager instance;

    public Text playerName;
    public Text playerMoney;

    public GameObject NormalFish;
    public GameObject NormalFish2;
    public GameObject HighQualityFish;
    public GameObject LegendFish;

    public GameObject StateBook;
    public GameObject FishDrawingBook;

    public GameObject StateBtn;
    public GameObject FishDrawingBookBtn;

    public GameObject BuyingHousePanel;
    public GameObject SuccessBuy;
    public GameObject FailtureBuy;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    public void UpdatePlayerUI(PlayerParams playerParams)
    {
        playerName.text = "Name : " + playerParams.name;
        playerMoney.text = "Money : " + playerParams.money.ToString() + " G";
    }

    public void OpenDBookUI()
    {
        StateBook.SetActive(true);
        StateBtn.SetActive(true);
        FishDrawingBookBtn.SetActive(true);
    }

    public void CloseDBookUI()
    {
        StateBook.SetActive(false);
        StateBtn.SetActive(false);
        FishDrawingBook.SetActive(false);
        FishDrawingBookBtn.SetActive(false);
    }

    public void StateOnBtn()
    {
        StateBook.SetActive(true);
        FishDrawingBook.SetActive(false);
    }

    public void DBookOnBtn()
    {
        FishDrawingBook.SetActive(true);
        StateBook.SetActive(false);
    }

    public void DBookObjectActive(int DBookNumber)
    {
        switch (DBookNumber)
        {
            case 0:
            case 1:
                NormalFish.SetActive(true);
                break;
            case 2:
            case 3:
                NormalFish2.SetActive(true);
                break;
            case 4:
            case 5:
            case 6:
                break;
            case 7:
                LegendFish.SetActive(true);
                break;
            case 8:
            case 9:
                HighQualityFish.SetActive(true);
                break;
        }
    }

    public void OpenBuyingHousePanel()
    {
        BuyingHousePanel.SetActive(true);
    }

    public void CloseBuyingHousePanel()
    {
        BuyingHousePanel.SetActive(false);
        SuccessBuy.SetActive(false);
        FailtureBuy.SetActive(false);
    }

    public void BuyingHouse(PlayerParams playerParams)
    {
        if (playerParams.money >= 1000)
        {
            SuccessBuy.SetActive(true);
           
        }
        else
        {
            FailtureBuy.SetActive(true);
            
        }
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
