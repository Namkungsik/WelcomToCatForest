using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookButtonManager : MonoBehaviour
{
    PlayerParams playerParams;

    public void StateButtonClick() // 상태 창 버튼 클릭 이벤트
    {
        DBookUIManager.instance.StateOnBtn();
    }

    public void DBookButtonClick()
    {
        DBookUIManager.instance.DBookOnBtn();
    }

}
