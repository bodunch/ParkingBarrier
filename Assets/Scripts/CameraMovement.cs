using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Transform player; // Посилання на гравця
    public float smoothTime = 0f;

    private Vector3 offset; // Відступ камери
    private Vector3 velocity = Vector3.zero;
    private Quaternion initialRotation; // Початковий кут камери

    void Start()
    {
        if (player)
        {
            offset = transform.position - player.position; // Рахуємо offset один раз при старті
            initialRotation = transform.rotation; // Запам'ятовуємо початковий поворот камери
        }
    }

    void FixedUpdate()
    {
        if (player)
        {
            // Розраховуємо нову позицію камери з урахуванням початкового offset
            Vector3 targetPosition = player.position + offset;

            // Плавно рухаємо камеру до цієї позиції
            transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);

            // Фіксуємо початковий поворот, щоб LookAt не змінював кут
            transform.rotation = initialRotation;
        }
    }
}
