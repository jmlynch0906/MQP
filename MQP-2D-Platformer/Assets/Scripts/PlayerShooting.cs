using System;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    [SerializeField] private GameObject pistolPrefab;

    [SerializeField] private GameObject shotgunPrefab;

   

    private String activePrefab = "Pistol";
    public Transform shootPoint;
    [SerializeField] private float attackTimer;
    private float cooldownTimer = Mathf.Infinity;

    
 

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && cooldownTimer > attackTimer)
        {
            Shoot();
        }

        if(Input.GetKeyDown(KeyCode.E)) {
            Swap();
        }

        cooldownTimer +=Time.deltaTime;
    }

    void Shoot()
    {   if(activePrefab == "Pistol"){
        GameObject projectile = Instantiate(pistolPrefab, shootPoint.position, shootPoint.rotation);
    }
        else if(activePrefab == "Shotgun"){
            GameObject projectile = Instantiate(shotgunPrefab, shootPoint.position, shootPoint.rotation);
            GameObject projectile1 = Instantiate(shotgunPrefab, shootPoint.position, shootPoint.rotation);
            projectile1.GetComponent<ProjectileShotgun>().SetVertSpeed(1f);
            GameObject projectile2 = Instantiate(shotgunPrefab, shootPoint.position, shootPoint.rotation);
            projectile2.GetComponent<ProjectileShotgun>().SetVertSpeed(-1f);
        }
        cooldownTimer =0;
        

        // Apply force to the projectile
        //projectileRb.velocity = shootPoint.right * projectileSpeed;
    }

//weaponSwap for debug purposes
    void Swap(){
        if (activePrefab == "Pistol") activePrefab = "Shotgun";
        else if (activePrefab == "Shotgun") activePrefab = "Pistol";
    }

    // OnTriggerEnter2D is called when the Collider2D other enters the trigger
/*    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Ground"))
        {
            // Destroy the projectile when it touches the ground
            Destroy(gameObject);
        }
    }*/
}
