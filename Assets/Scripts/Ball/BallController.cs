using UnityEngine;

public class BallController : MonoBehaviour
{
    [SerializeField] MatchConfigSO matchConfig;
    private Rigidbody2D rb;
    private float currentSpeed;
    private bool isActive = false;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        currentSpeed = matchConfig.InitialSpeed;
    }

    private void Start()
    {
        LaunchBall();
    }

    private void LaunchBall()
    {
        float randomAngle = Random.Range(-matchConfig.MaxAngle, matchConfig.MaxAngle) * Mathf.Deg2Rad;
        int randomHorizontalDir = Random.Range(0, 2) == 0 ? -1 : 1;

        float xComponent = Mathf.Cos(randomAngle) * randomHorizontalDir;
        float yComponent = Mathf.Sin(randomAngle);

        Vector2 direction = new Vector2(xComponent, yComponent).normalized;
        rb.linearVelocity = direction * currentSpeed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            //OnHitWall();
        }
        else if (collision.gameObject.CompareTag("Paddle"))
        {
            OnHitPaddle();
        }
    }

    private void OnHitPaddle()
    {

    }
}

