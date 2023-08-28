using System.Collections;
using UnityEngine;

public class TextureInteraction : MonoBehaviour
{
    private Color originalColor;
    public Color endColor;
    public float transitionDuration = 2.0f;
    private bool isInteracting = false;

    private SpriteRenderer spriteRenderer;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        originalColor = spriteRenderer.color;
    }

    private void Update()
    {
        if (isInteracting)
        {
            StartCoroutine(TransitionColor());
            isInteracting = false; // Сброс флага
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) // Замените на тег вашего персонажа
        {
            isInteracting = true;
        }
    }

    private IEnumerator TransitionColor()
    {
        float elapsedTime = 0.0f;

        while (elapsedTime < transitionDuration)
        {
            float t = elapsedTime / transitionDuration;
            Color lerpedColor = Color.Lerp(originalColor, endColor, t);

            spriteRenderer.color = lerpedColor;

            elapsedTime += Time.deltaTime;
            yield return null;
        }

        spriteRenderer.color = endColor;
    }
}
