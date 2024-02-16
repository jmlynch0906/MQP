using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Cache;
using JetBrains.Annotations;
using UnityEngine;

public class BadGuyMovement : MonoBehaviour
{

    public Rigidbody2D rb;

//enemiees will constantly move left towards the player
    public float speed = -1f;

    //enemies will only start to advance when seen, as to prevent every enemy from moving and falling off the map before they are reached
    public bool isSeen = false;
    public float obstacleCheckRadius = 1.5f;
    public LayerMask wallLayer;




    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
       
    }

    // Update is called once per frame
    void Update()
    {
        //checks if enemy is seen
        if(isSeen){

            rb.velocity = new Vector2(speed,rb.velocity.y);
            //checks if enemy is bumping into a wall. Change speed if thats the case.
            if(isBlocked()){
                speed = - speed;
            }

        }
        
    }

    void OnBecameVisible(){
        isSeen = true;
    }

    Boolean isBlocked(){
                Vector2 start = transform.position;
        Vector2 direction = new Vector2(speed, 0f);

        RaycastHit2D[] hits = Physics2D.RaycastAll(start, direction, obstacleCheckRadius);

        // Filter out hits from the enemy itself
        hits = System.Array.FindAll(hits, hit => hit.collider.gameObject != gameObject && hit.collider.gameObject != GameObject.Find("Player"));

        return hits.Length > 0;
    }
}
