using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorController : MonoBehaviour
{
    private Animator animator;
    private CharacterMovement characterMovement;
    private bool flippedThisAir;
    public void Start()
    {
        animator = GetComponent<Animator>();
        characterMovement = GetComponent<CharacterMovement>();
    }
    public void LateUpdate()
    {
       UpdateAnimator();
        if (characterMovement.IsGrounded) flippedThisAir = false;
    }

    // TODO Fill this in with your animator calls
    void UpdateAnimator()
    {
        if (!characterMovement.IsGrounded && Input.GetButtonDown("Jump") && characterMovement.doubleJumpUnlocked)
        {
            animator.SetTrigger("Flip");
        }
        
        animator.SetFloat("CharacterSpeed", characterMovement.groundSpeed);
        animator.SetBool("isGrounded", characterMovement.IsGrounded);
        animator.SetFloat("VerticalSpeed", characterMovement.VerticalVelocity);

       
    }
}
