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

        // Скасовуємо попередній виклик закриття, якщо він був
        CancelInvoke("CloseGate");

        // Запускаємо закриття через 5 секунд
        Invoke("CloseGate", 5f);
    }

    private void CloseGate()
    {
        // Перед закриттям перевіряємо, чи гравець все ще в тригері
        if (!isInTrigger)
        {
            gateCollider.SetActive(true);
            gateAnimator.SetBool("isOpenGate", false);
            Debug.Log("Ворота закрито");
        }
        else
        {
            Debug.Log("Гравець у тригері - ворота залишаються відкритими");
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isInTrigger = true;
            Debug.Log("Гравець увійшов у тригер");
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isInTrigger = false;
            Debug.Log("Гравець вийшов із тригера");
        }
    }
}
