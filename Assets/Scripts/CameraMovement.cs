using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Transform player; // ��������� �� ������
    public float smoothTime = 0f;

    private Vector3 offset; // ³����� ������
    private Vector3 velocity = Vector3.zero;
    private Quaternion initialRotation; // ���������� ��� ������

    void Start()
    {
        if (player)
        {
            offset = transform.position - player.position; // ������ offset ���� ��� ��� �����
            initialRotation = transform.rotation; // �����'������� ���������� ������� ������
        }
    }

    void FixedUpdate()
    {
        if (player)
        {
            // ����������� ���� ������� ������ � ����������� ����������� offset
            Vector3 targetPosition = player.position + offset;

            // ������ ������ ������ �� ���� �������
            transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);

            // Գ����� ���������� �������, ��� LookAt �� ������� ���
            transform.rotation = initialRotation;
        }
    }
}
