using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InputManager : MonoBehaviour
{
    GameObject player;

    // Start is called before the first frame update 
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void CheckClick()
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }
        if (Input.GetMouseButtonDown(0))
        {
            //ī�޶�κ��� ȭ����� ��ǥ�� �����ϴ� ������ ��(����)�� �����ؼ� ������ �ִ� �Լ� 
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            RaycastHit hit;

            //Physics.Raycast(���� Ÿ�� ����, out ���� ĳ��Ʈ ��Ʈ Ÿ�Ժ���) :  
            //������ ��������(����)�� �浹ü�� �浹�ϸ�, true(��) ���� �����ϸ鼭 ���ÿ� ����ĳ��Ʈ ��Ʈ ������ �浹 ����� ������ ��� �ִ� �Լ�    

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.gameObject.name == "Floor")
                {
                    //player.transform.position = hit.point;
                    player.GetComponent<Player>().MoveTo(hit.point);
                }
                else if (hit.collider.gameObject.tag == "Object")//���콺 Ŭ���� ����� �� ĳ������ ���
                {
                    player.GetComponent<Player>().InteractObj(hit.collider.gameObject);
                }
            }
        }
    }

    // Update is called once per frame 
    void Update()
    {
        CheckClick();
    }
}
