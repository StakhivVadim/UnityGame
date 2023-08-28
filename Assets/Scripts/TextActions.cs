using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelCompleted : MonoBehaviour
{
    public Text displayText; // ������ �� ��������� Text
    public string text;

    private void Start()
    {
        // �������� � ������ ���������
        if (displayText != null)
        {
            displayText.enabled = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && displayText != null) // �������� �� ��� ������� � ������� ������
        {
            // ���������� �����
            displayText.enabled = true;
            displayText.text = text;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player") && displayText != null) // �������� �� ��� ������� � ������� ������
        {
            // �������� �����
            displayText.enabled = false;
        }
    }
}
