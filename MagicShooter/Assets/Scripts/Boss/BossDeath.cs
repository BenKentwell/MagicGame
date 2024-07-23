using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossDeath : MonoBehaviour
{
    [SerializeField] private Animator animator;

    void Start()
    {
        
    }

    public void StartCinematic()
    {
        Camera.main.enabled = false;

        animator.Play("BossDeathTemp");
    }
}
