using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class AnimationManager : MonoBehaviour
{
    [SerializeField] Animator animator;
    [SerializeField] AnimationClip[] animationClip;

    void Start()
    {
        for (int i = 0; i < animationClip.Length; i++)
        {
            AnimationClipSettings data = AnimationUtility.GetAnimationClipSettings(animationClip[i]);

            data.loopTime = false;

            AnimationUtility.SetAnimationClipSettings(animationClip[i], data);
        }
    }

    void Update()
    {
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("Close"))
        {
            // animator.GetCurrentAnimatorStateInfo(0).normalizedTime
            // 현재 진행한 애니메이션의 실행 상태를 의미합니다.
            if (animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1)
            {
                animator.gameObject.SetActive(false);
            }
        }
    }

    public void Open()
    {
        animator.gameObject.SetActive(true);
    }

    public void Close()
    {
        animator.SetTrigger("Close");
    }
}