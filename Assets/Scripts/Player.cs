using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float moveSpeed = 3f;
    public float startDelay = 1f; // Задержка перед началом движения в секундах
    public int damage = 1;
    public GameObject playerChangeAnimation;
    private bool isMoving = false;
    private Player_change_animations playerChangeAnimations;

    private void Start()
    {
        playerChangeAnimations = playerChangeAnimation.GetComponent<Player_change_animations>();
        StartCoroutine(StartDelayedMovement());
    }

    // Метод для передачи задержки
    public float Delay()
    {
        return startDelay;
    }

    private IEnumerator StartDelayedMovement()
    {
        // Задержка перед началом движения
        yield return new WaitForSeconds(startDelay);
        playerChangeAnimations.PlayAnimation();
    }

    private void Update()
    {
        // Проверяем, нужно ли двигаться
        isMoving = playerChangeAnimations.IsMoving();
        damage = isMoving ? 1 : 0;
        if (isMoving)
        {
            // Выполняем автоматическое движение
            transform.Translate(Vector2.right * moveSpeed * Time.deltaTime);
        }
    }    
}
