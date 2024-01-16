using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveShootPoint : MonoBehaviour
{


     public SpriteRenderer sprite;

     public Transform t;
    // Start is called before the first frame update
        void Start()
    {
        t = GetComponent<Transform>();
        sprite = GetComponentInParent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(sprite.flipX==true){
            transform.localPosition = new Vector3(-.25f,0,0);
        }
        else{
            transform.localPosition = new Vector3(.25f,0,0);
        }
    }
}
