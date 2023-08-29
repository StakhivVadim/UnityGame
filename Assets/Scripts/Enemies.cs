using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Spine.Unity;

public class Enemy : MonoBehaviour
{
    // Переменные противника
    public int health = 1;
    public float speed = 3f;
    public Transform player;
    public int takeDamage;
    private Player playerComponent;
    private ParticleSystem explosionParticleSystem;
    private ParticleSystem DropletsParticleSystem;
    public Transform explosionPoint;
    public GameObject explosionPrefab;
    private Enemy_change enemyChangeComponent;
    private float distance;
    private bool isMoving = false;
    private int agroDistance = 25;
    private int minDistance = 5;

    private void Start()
    {
        enemyChangeComponent = GetComponentInChildren<Enemy_change>();
        playerComponent = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        if (playerComponent == null)
        {
            Debug.LogError("PlayerMove component not found.");
        }
        distance = Vector2.Distance(transform.position, player.position);
    }

    private void Update()
    {
        if (playerComponent == null)
        {
            return;
        }
        takeDamage = playerComponent.damage;
        distance = Vector2.Distance(transform.position, player.position);
        if (distance < agroDistance && distance > minDistance && !isMoving)
        {
            StartMoving();
        }

        if (isMoving)
        {
            Move();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        StopMoving();
    }

    private void OnMouseDown()
    {
        if (takeDamage > 0)
        {
            Attack();
        }

        health -= takeDamage;

        if (health <= 0)
        {
            Die();
        }
    }

    private void StartMoving()
    {
        if (enemyChangeComponent != null)
        {
            enemyChangeComponent.PlayAnimationRun();
        }

        isMoving = true;
    }

    private void Move()
    {
        transform.Translate(Vector2.left * speed * Time.deltaTime);
    }

    private void StopMoving()
    {
        isMoving = false;
    }

    private void Attack()
    {
        PlayExplosionAnimation();
    }

    private void Die()
    {
        StartCoroutine(DieCoroutine(0.1f));
    }

    private IEnumerator DieCoroutine(float delay)
    {
        yield return new WaitForSeconds(delay);
        Destroy(gameObject);
    }

    public void PlayExplosionAnimation()
    {
        if (explosionPrefab == null || explosionPoint == null)
        {
            Debug.LogError("ExplosionPrefab or explosionPoint is not assigned.");
            return;
        }
        GameObject explosionInstance = Instantiate(explosionPrefab, transform.position, Quaternion.identity);
        ExplosionAnimation explosionAnimation = explosionInstance.GetComponent<ExplosionAnimation>();
        if (explosionAnimation != null)
        {
            explosionAnimation.explosionPoint = explosionPoint;
            explosionAnimation.PlayExplosionAnimation();
        }
    }
}
