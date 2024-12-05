using OkapiKit;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed;
    public ArrowControl arrow;
    public AudioClip coinPickup;
    float bounceTime;

    Rigidbody2D rb;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.simulated = false;
    }

    private void Update()
    {
        if (rb.simulated)
        {
            if (rb.linearVelocity.magnitude < 1e-6)
            {
                rb.simulated = false;
                rb.linearVelocity = Vector2.zero;

                arrow.Activate();
            }
        }
    }

    public void Bounce()
    {
        rb.simulated = true;
        rb.linearVelocity = arrow.transform.up * speed;

        bounceTime = Time.time;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if ((Time.time - bounceTime) > 0.2f)
        {
            // Collided
            rb.simulated = false;
            rb.linearVelocity = Vector2.zero;

            var contact = collision.GetContact(0);
            transform.position = contact.point;
            transform.rotation = Quaternion.LookRotation(Vector3.forward, contact.normal);

            arrow.Activate();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var coin = collision.GetComponent<Coin>();
        if (coin != null)
        {
            SoundManager.PlaySound(SoundType.PrimaryFX, coinPickup, 1.0f, Random.Range(0.8f, 1.2f));
            Destroy(coin.gameObject);
        }
    }
}
