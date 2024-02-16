using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BadGuyLife : MonoBehaviour
{
    private BoxCollider2D box;

    private SpriteRenderer sprite;
  


    private bool isSeen = false;

  private void Start()
    {
        box = GetComponent<BoxCollider2D>();
        sprite = GetComponent<SpriteRenderer>();
    }


    private void OnCollisionEnter2D(Collision2D collision){
        if(collision.gameObject.CompareTag("player bullet") && isSeen){
            Die();
        }
    }

    private void Die(){
        
        box.enabled = false;
        sprite.enabled = false;
        Invoke("DestroyEnemy",1f);
    }

    private void DestroyEnemy(){
         Destroy(gameObject);
    }

        void OnBecameVisible(){
        isSeen = true;
    }


}
