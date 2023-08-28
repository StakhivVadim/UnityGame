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
            // ������ ������� ��������� ����� ��������������� ��������
            explosionParticleSystem.transform.position = explosionPoint.position;
            // ��������� �������� �������� �� ������� Muzzle
            explosionParticleSystem.Play();
        }
        if (dropletsParticleSystem != null)
        {
            dropletsParticleSystem.Play();
        }
        // ������������� ���� ������
        if (explosionAudio != null)
        {
            explosionAudio.Play();
        }
    }
}
