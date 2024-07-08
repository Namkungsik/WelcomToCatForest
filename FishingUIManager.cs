using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FishingUIManager : MonoBehaviour
{
    // ���� ��𼭳� ���� �����Ҽ� �ֵ��� �ϱ����� ���� ��������
    public static FishingUIManager instance;

    public GameObject NormalFish;
    public GameObject NormalFish2;
    public GameObject HighQualityFish;
    public GameObject LegendFish;

    public Text FishPrice;

    private float DeActTime = 2f;
    private float currentDeActTime = 0f;

    public GameObject Player;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    public void UpdatePlayerUI(int FishingNum)
    {
        switch (FishingNum)
        {
            case 0:
            case 1:
                NormalFish.SetActive(true);
                FishPrice.text = "+ 100";
                Debug.Log("�Ϲ� �����");
                Player.GetComponent<PlayerParams>().AddMoney(100);
                break;
            case 2:
            case 3:

                NormalFish2.SetActive(true);
                FishPrice.text = "+ 100";
                Debug.Log("�Ϲ� �����2");
                Player.GetComponent<PlayerParams>().AddMoney(100);
                break;
            case 4:
            case 5:
            case 6:
                FishPrice.text = "+ 0";
                Debug.Log("������..");
                break;
            case 7:
                LegendFish.SetActive(true);
                FishPrice.text = "+ 1000";
                Debug.Log("���� �����");
                Player.GetComponent<PlayerParams>().AddMoney(1000);
                break;
            case 8:
            case 9:
                HighQualityFish.SetActive(true);
                FishPrice.text = "+ 500";
                Debug.Log("��� �����");
                Player.GetComponent<PlayerParams>().AddMoney(500);
                break;
        }
        DBookUIManager.instance.DBookObjectActive(FishingNum);
    }

    void DeActive()
    {
        if (currentDeActTime >= DeActTime)
        {
            NormalFish.SetActive(false);
            NormalFish2.SetActive(false);
            LegendFish.SetActive(false);
            HighQualityFish.SetActive(false);
            FishPrice.text = "";
            currentDeActTime = 0f; // Reset the timer
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (currentDeActTime < DeActTime)
        {
            currentDeActTime += Time.deltaTime;
        }

        DeActive();
    }
}
