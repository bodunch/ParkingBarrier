using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateManager : MonoBehaviour
{
    public GameObject gateCollider;
    public Animator gateAnimator;
    public bool isInTrigger = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            OpenGate();
        }

    }

    private void OpenGate()
    {
        gateCollider.SetActive(false);
        gateAnimator.SetBool("isOpenGate", true);

        // ��������� ��������� ������ ��������, ���� �� ���
        CancelInvoke("CloseGate");

        // ��������� �������� ����� 5 ������
        Invoke("CloseGate", 5f);
    }

    private void CloseGate()
    {
        // ����� ��������� ����������, �� ������� ��� �� � ������
        if (!isInTrigger)
        {
            gateCollider.SetActive(true);
            gateAnimator.SetBool("isOpenGate", false);
            Debug.Log("������ �������");
        }
        else
        {
            Debug.Log("������� � ������ - ������ ����������� ���������");
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isInTrigger = true;
            Debug.Log("������� ������ � ������");
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isInTrigger = false;
            Debug.Log("������� ������ �� �������");
        }
    }
}
