using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionAnimation : MonoBehaviour
{
    private ParticleSystem explosionParticleSystem;
    private ParticleSystem dropletsParticleSystem;
    private AudioSource explosionAudio;
    public Transform explosionPoint;

    public void PlayExplosionAnimation()
    {
        explosionParticleSystem = GetComponent<ParticleSystem>();
        dropletsParticleSystem = transform.Find("Droplets").GetComponent<ParticleSystem>();
        explosionAudio = transform.Find("Sound").GetComponent<AudioSource>();
        if (explosionParticleSystem != null && explosionPoint != null)
        {
            // Задаем позицию начальной точки воспроизведения анимации
            explosionParticleSystem.transform.position = explosionPoint.position;
            // Запускаем анимацию выстрела на объекте Muzzle
            explosionParticleSystem.Play();
        }
        if (dropletsParticleSystem != null)
        {
            dropletsParticleSystem.Play();
        }
        // Воспроизводим звук взрыва
        if (explosionAudio != null)
        {
            explosionAudio.Play();
        }
    }
}
