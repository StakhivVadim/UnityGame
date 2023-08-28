using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAutoMove : MonoBehaviour
{
    public Transform target; // ������, �� ������� ������� ������
    public float smoothSpeed = 0.125f; // �������� ����������� ����������
    public float stopThreshold = 374; // ����� ��� ��������� ������

    private Vector3 offset;

    private void Start()
    {
        offset = transform.position - target.position;
    }

    private void LateUpdate()
    {
        float currentPos = transform.position.x;

        if (currentPos < stopThreshold)
        {
            Vector3 desiredPosition = target.position + offset;
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
            transform.position = smoothedPosition;
        }
    }
}
