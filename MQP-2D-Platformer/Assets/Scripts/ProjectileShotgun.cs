using UnityEngine;

public class ProjectileShotgun : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float vertSpeed; // Default to 0
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
        float vertMovementSpeed = vertSpeed;

        
        rb.velocity = new Vector2(movementSpeed, vertMovementSpeed);

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

    public void SetVertSpeed(float speed)
    {
        vertSpeed = speed;
    }
}