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

    public SpriteRenderer sprite;

    public int dir = 1;
    
 
  void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
    }
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

        if(sprite.flipX == true){
            dir=-1;
        }
        else{
            dir =1;
        }
    }

    void Shoot()
    {   if(activePrefab == "Pistol"){
        GameObject projectile = Instantiate(pistolPrefab, shootPoint.position, shootPoint.rotation);
        projectile.GetComponent<ProjectilePistol>().SetDirection(dir);
    }
        else if(activePrefab == "Shotgun"){
            GameObject projectile = Instantiate(shotgunPrefab, shootPoint.position, shootPoint.rotation);
            projectile.GetComponent<ProjectileShotgun>().SetDirection(dir);
            GameObject projectile1 = Instantiate(shotgunPrefab, shootPoint.position, shootPoint.rotation);
            projectile1.GetComponent<ProjectileShotgun>().SetVertSpeed(2f);
            projectile1.GetComponent<ProjectileShotgun>().SetDirection(dir);
            GameObject projectile2 = Instantiate(shotgunPrefab, shootPoint.position, shootPoint.rotation);
            projectile2.GetComponent<ProjectileShotgun>().SetVertSpeed(-2f);
            projectile2.GetComponent<ProjectileShotgun>().SetDirection(dir);
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
