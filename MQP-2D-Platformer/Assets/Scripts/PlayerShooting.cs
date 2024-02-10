using System;
using EmergenceSDK.Samples.Examples;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    [SerializeField] private GameObject pistolPrefab;

    [SerializeField] private GameObject shotgunPrefab;

   

    private String activePrefab = "none";
    public Transform shootPoint;
    [SerializeField] private float attackTimer;
    private float cooldownTimer = Mathf.Infinity;
    private EquippedPersona currentPersona;


    public SpriteRenderer sprite;

    public int dir = 1;
    
 
  void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        currentPersona = GetComponent<EquippedPersona>();
    }
    void Update()
    {
        activePrefab = currentPersona.getName();
        if (Input.GetKeyDown(KeyCode.F) && cooldownTimer > attackTimer)
        {
            Shoot();
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
