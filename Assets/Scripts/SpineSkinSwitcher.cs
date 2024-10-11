using Spine.Unity;
using Spine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpineSkinSwitcher : MonoBehaviour
{
    // Reference to the SkeletonAnimation component on your character
    public SkeletonAnimation skeletonAnimation;

    // Method to change the skin of the skeleton
    public void ChangeSkin(string skinName)
    {
        // Get the skeleton from the SkeletonAnimation component
        Skeleton skeleton = skeletonAnimation.Skeleton;

        // Get the desired skin by name
        Skin newSkin = skeleton.Data.FindSkin(skinName);

        if (newSkin != null)
        {
            // Set the new skin on the skeleton
            skeleton.SetSkin(newSkin);
            skeleton.SetSlotsToSetupPose(); // This resets the slots to match the new skin's attachments
        }
        else
        {
            Debug.LogWarning($"Skin '{skinName}' not found.");
        }

        // Optionally, you can apply any updates needed
        skeletonAnimation.Update(0);
    }
}
