using Spine.Unity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Spine;

public class SpineAnimationController : MonoBehaviour 
{
    [SerializeField] public SkeletonAnimation skeletonAnimation;

    /// <summary>
    /// Plays a specified Spine animation.
    /// </summary>
    /// <param name="animationName">Name of the animation to play.</param>
    /// <param name="loop">Should the animation loop?</param>
    public void PlaySpineAnimation(string animationName, bool loop = true)
    {
        // Check if the animation exists in the skeleton data
        var animation = skeletonAnimation.Skeleton.Data.FindAnimation(animationName);

        if (animation != null)
        {
            // Set the animation to play
            skeletonAnimation.AnimationState.SetAnimation(0, animationName, loop);
        }
        else
        {
            Debug.LogWarning($"Animation '{animationName}' not found in the skeleton.");
        }
    }
}
