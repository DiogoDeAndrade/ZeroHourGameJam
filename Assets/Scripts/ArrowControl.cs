using UnityEngine;

public class ArrowControl : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public Player         player;
    public float turnSpeed = 180.0f;
    public int   nLoops = 5;

    float angle;
    float angleInc;
    int loopCount;

    void Start()
    {
        gameObject.SetActive(false);
    }

    void Update()
    {
        transform.localRotation = Quaternion.Euler(0, 0, angle);

        angle += angleInc * turnSpeed * Time.deltaTime;
        if ((angleInc < 0.0f) && (angle < -45.0f))
        {
            loopCount++;
            angleInc = 1.0f;
        }
        else if ((angleInc > 0.0f) && (angle > 45.0f))
        {
            loopCount++;
            angleInc = -1.0f;
        }

        if (loopCount > nLoops)
        {
            spriteRenderer.color = Color.red;
            if (Random.Range(0.0f, 1.0f) < 0.025f)
            {
                Bounce();
            }
        }
        else
        {
            if (Input.GetButtonDown("Jump"))
            {
                Bounce();
            }
        }

    }

    public void Activate()
    {
        angle = 0.0f;
        angleInc = -1.0f;
        loopCount = 0;
        gameObject.SetActive(true);
        spriteRenderer.color = Color.green;
    }

    void Bounce()
    {
        player.Bounce();
        gameObject.SetActive(false);        
    }
}
