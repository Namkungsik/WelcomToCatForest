using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookButtonManager : MonoBehaviour
{
    PlayerParams playerParams;

    public void StateButtonClick() // ���� â ��ư Ŭ�� �̺�Ʈ
    {
        DBookUIManager.instance.StateOnBtn();
    }

    public void DBookButtonClick()
    {
        DBookUIManager.instance.DBookOnBtn();
    }

}
