using UnityEngine;
using System.Collections;

public class ProjectileSpawner_ArunSwordsmith : MonoBehaviour {

    [SerializeField] GameObject projectile;

    private Transform projectile_SpawnPoint;

    void Start()
    {
        projectile_SpawnPoint = transform.Find("Projectile_SpawnPoint");
    }

    // This function is called as an event in the animations
    public void spawnProjectile()
    {
        if (projectile_SpawnPoint != null)
        {
            GameObject newProjectile = Instantiate(projectile, projectile_SpawnPoint.position, projectile_SpawnPoint.rotation) as GameObject;
            // Turn projectile in correct direction
            newProjectile.transform.localScale = transform.localScale;
        }
    }
}
