using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MuzzleAnimation : MonoBehaviour
{
    private ParticleSystem muzzleParticleSystem;
    private ParticleSystem lightningBoltsParticleSystem;
    private ParticleSystem glowParticleSystem;
    private AudioSource shootAudio;
    public Transform shootPoint; 

    public void PlayMuzzleAnimation()
    {
        muzzleParticleSystem = GetComponent<ParticleSystem>();
        lightningBoltsParticleSystem = transform.Find("LightningBolts").GetComponent<ParticleSystem>();
        glowParticleSystem = transform.Find("Glow").GetComponent<ParticleSystem>();
        shootAudio = transform.Find("shoot").GetComponent<AudioSource>();
        if (muzzleParticleSystem != null && shootPoint != null)
        {
            // Задаем позицию начальной точки воспроизведения анимации
            muzzleParticleSystem.transform.position = shootPoint.position;
            // Запускаем анимацию выстрела на объекте Muzzle
            muzzleParticleSystem.Play();
        }
        if (lightningBoltsParticleSystem != null)
        {
            lightningBoltsParticleSystem.Play();
        }
        if (glowParticleSystem != null)
        {
            glowParticleSystem.Play();
        }
        if (shootAudio != null)
        {
            shootAudio.Play();
        }
    }
}
