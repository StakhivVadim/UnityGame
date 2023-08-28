using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Spine.Unity;

public class Enemy_change : MonoBehaviour
{
    public SkeletonAnimation skeletonAnimation;
    public string runAnimation;
    public string winAnimation;

    public void PlayAnimationRun()
    {
        skeletonAnimation.AnimationState.SetAnimation(0, runAnimation, true);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            skeletonAnimation.AnimationState.SetAnimation(0, winAnimation, true);
        }
    }
}
