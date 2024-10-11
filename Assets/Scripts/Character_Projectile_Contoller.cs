using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character_Projectile_Contoller : MonoBehaviour
{
    [SerializeField] private GameObject projectilePrefab; 
    [SerializeField] private Transform spawnPoint;        
    [SerializeField] private float projectileSpeed = 10f; 
    [SerializeField] private float distanceToTravel = 10f; 

    public void ShootProjectile(int direction)
    {
        GameObject projectile = Instantiate(projectilePrefab, spawnPoint.position, spawnPoint.rotation);

        Vector3 targetPosition = projectile.transform.position + Vector3.right*direction * distanceToTravel;

        LeanTween.move(projectile, targetPosition, distanceToTravel / projectileSpeed)
            .setOnComplete(() =>
            {
                Destroy(projectile);
            });
    }
}
