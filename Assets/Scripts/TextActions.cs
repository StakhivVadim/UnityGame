using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelCompleted : MonoBehaviour
{
    public Text displayText; // Ссылка на компонент Text
    public string text;

    private void Start()
    {
        // Начинаем с текста невидимым
        if (displayText != null)
        {
            displayText.enabled = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && displayText != null) // Проверка на тег объекта и наличие текста
        {
            // Показываем текст
            displayText.enabled = true;
            displayText.text = text;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player") && displayText != null) // Проверка на тег объекта и наличие текста
        {
            // Скрываем текст
            displayText.enabled = false;
        }
    }
}
