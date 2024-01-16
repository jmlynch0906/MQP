using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BadGuyMovement : MonoBehaviour
{

    public Rigidbody2D rb;

//enemiees will constantly move left towards the player
    public float speed = -1f;

    //enemies will only start to advance when seen, as to prevent every enemy from moving and falling off the map before they are reached
    public bool isSeen = false;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(isSeen){
            rb.velocity = new Vector2(speed,rb.velocity.y);
        }
        
    }

    void OnBecameVisible(){
        isSeen = true;
    }
}
