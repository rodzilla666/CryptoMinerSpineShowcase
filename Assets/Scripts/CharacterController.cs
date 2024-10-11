using Spine.Unity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Spine;
using System;

public class CharacterController : MonoBehaviour
{
    [SerializeField] private SpineAnimationController spineAnimationController;
    [SerializeField] private CharacterMovement characterMovement;
    [SerializeField] private Character_Projectile_Contoller characterProjectileController;
    [SerializeField] private Character_Input_Handler characterInputHandler;
    [SerializeField] private Particle_Controller characterParticleController;

    [SerializeField] private string walkingAnimationName;
    [SerializeField] private string idleAnimationName;

    private void OnEnable()
    {
       // spineAnimationController.skeletonAnimation.AnimationState.Event += OnAnimationEvent;
        characterInputHandler.onMove += OnMove;
    }

    private void OnDisable()
    {
       // spineAnimationController.skeletonAnimation.AnimationState.Event -= OnAnimationEvent;
        characterInputHandler.onMove -= OnMove;
    }

    private void OnMove(string state)
    {
        switch(state)
        {
            case "MoveLeft":
                {
                    Move(-1);
                    break;
                }
            case "MoveRight":
                {
                    Move(1);
                    break;
                }
            case "Canceled":
                {
                    StopMoving();
                    break;
                }
        }
    }

    private void OnAnimationEvent(TrackEntry trackEntry, Spine.Event e)
    {
        if (!e.Data.Name.Contains("Die"))
        {
            spineAnimationController.PlaySpineAnimation("Idle", true);
        }
        else
        {
            if (characterParticleController != null)
            {
                LeanTween.delayedCall(0.5f, () =>
                {
                    characterParticleController.Play();
                    transform.Find("CharacterSprite").GetComponent<MeshRenderer>().enabled = false;
                    LeanTween.delayedCall(1f, () =>
                    {
                        spineAnimationController.PlaySpineAnimation("Idle", true);
                        transform.Find("CharacterSprite").GetComponent<MeshRenderer>().enabled = true;
                    });
                });
            }
        }
        if (e.Data.Name.Contains("Shoot"))
        {
            if (characterProjectileController != null)
            {
                characterProjectileController.ShootProjectile(characterMovement.GetDirection());
            }
        }
    }

    public void PlayAnimation(string animationName)
    {
        transform.Find("CharacterSprite").GetComponent<MeshRenderer>().enabled = true;
        if(animationName.Contains("Work") || animationName.Contains("Idle") || animationName.Contains("Typing"))
        {
            spineAnimationController.PlaySpineAnimation(animationName, true);
        }
        else
        {
            spineAnimationController.PlaySpineAnimation(animationName, false);
        }
    }

    public void Move(int direction)
    {
        characterMovement.SetDirection(direction);
        characterMovement.RotateCharacterSprite();
        characterMovement.Move();
        spineAnimationController.PlaySpineAnimation(walkingAnimationName, true);
    }

    public void StopMoving()
    {
        characterMovement.Stop();
        spineAnimationController.PlaySpineAnimation(idleAnimationName, true);
    }

}
