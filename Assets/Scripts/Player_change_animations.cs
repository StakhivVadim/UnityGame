using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Spine.Unity;
using Spine;

public class Player_change_animations : MonoBehaviour
{
    public SkeletonAnimation skeletonAnimation;
    public string runAnimation;
    public string dieAnimation;
    public string attackAnimation;
    public string missAnimation;
    private bool isMoving = false;
    private bool isAnimating = false;
    private TrackEntry dieAnimationTrack;
    private float elapsedTime = 0.0f;
    private float animationDuration = 1.15f;
    bool alive = true;
    public Transform shootPoint;
    public GameObject muzzlePrefab;

    public void PlayAnimation()
    {
        isMoving = true;
        skeletonAnimation.AnimationState.SetAnimation(0, runAnimation, true);
    }

    private void Start()
    {
        //skeletonAnimation.AnimationState.Complete += AnimationComplete;
    }

    private void Update()
    {
        if (dieAnimationTrack != null)
        {
            CheckAlive();
        }
        if (isAnimating)
        {
            isMoving = false;
        }
        // Проверка на нажатие мыши
        if (Input.GetMouseButtonDown(0) && alive && isMoving)
        {
            isAnimating = true;
            isMoving = false;
            ShootAnimation();
        }
    }

    // Метод для передачи состояния движения
    public bool IsMoving()
    {
        return isMoving;
    }

    private void CheckAlive()
    {
        elapsedTime += Time.deltaTime;
        if (elapsedTime >= animationDuration)
        {
            skeletonAnimation.AnimationState.TimeScale = 0; // Остановить анимацию на последнем кадре
        }
    }

    private void ShootAnimation()
    {
        // Создаем объект Muzzle с помощью Instantiate
        GameObject muzzleInstance = Instantiate(muzzlePrefab, transform.position, Quaternion.identity);
        // Получаем компонент MuzzleAnimation на созданном объекте Muzzle
        MuzzleAnimation muzzleAnimation = muzzleInstance.GetComponent<MuzzleAnimation>();
        // Вызываем метод для воспроизведения анимации Muzzle
        if (muzzleAnimation != null)
        {
            muzzleAnimation.shootPoint = shootPoint;
            muzzleAnimation.PlayMuzzleAnimation();
        }
        ChooseShootAnimation();
    }

    private void ChooseShootAnimation()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction);
        isMoving = false; // Остановить движение при анимации выстрела
        if (hit.collider == null)
        {
            PlayMissAnimation();
        }
        else if (hit.collider.CompareTag("Enemy"))
        {
            PlayHitAnimation();
        }
    }

    private void PlayHitAnimation()
    {
        skeletonAnimation.AnimationState.SetAnimation(0, attackAnimation, false);
        AnimationComplete(2.0f);
    }

    private void PlayMissAnimation()
    {
        skeletonAnimation.AnimationState.SetAnimation(0, missAnimation, false);
        AnimationComplete(2.733f);
    }

    private void AnimationComplete(float time)
    {
        StartCoroutine(StopCoroutine(time));
    }

    private IEnumerator StopCoroutine(float delay)
    {
        yield return new WaitForSeconds(delay);
        skeletonAnimation.AnimationState.SetAnimation(0, runAnimation, true);
        isMoving = true;
        isAnimating = false;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            dieAnimationTrack = skeletonAnimation.AnimationState.SetAnimation(0, dieAnimation, true);
            alive = false;
            isMoving = false;
        }
        if (other.CompareTag("Finish"))
        {
            Destroy(transform.parent.gameObject);
        }
    }
}