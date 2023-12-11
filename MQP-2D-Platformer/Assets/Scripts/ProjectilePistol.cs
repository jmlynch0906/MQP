using UnityEngine;

public class ProjectilePistol : MonoBehaviour
{
    [SerializeField] private float speed;
    private bool hit;
    private float direction = 1;
    [SerializeField] private float maxFlightTime;

    private float flightTime = 0f;
    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        Physics2D.IgnoreLayerCollision(gameObject.layer, gameObject.layer);
    }

    private void Update()
    {
        float movementSpeed = speed * direction;
   
        
        rb.velocity = new Vector2(movementSpeed, 0);

        flightTime += Time.deltaTime;

        if (flightTime >= maxFlightTime) Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == GameObject.Find("Player")) return;
        hit = true;
        Destroy(gameObject);
    }

    public void SetDirection(float dir)
    {
        direction = dir;
        hit = false;
    }


}