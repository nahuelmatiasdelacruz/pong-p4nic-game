using System.Collections;
using UnityEngine;

public class BallController : MonoBehaviour
{
    [SerializeField] MatchConfigSO matchConfig;
    private Vector3 initialBallPosition;
    private Rigidbody2D rb;
    private float currentSpeed;
    private bool isActive = false;

    private void Awake()
    {
        initialBallPosition = transform.position;
        rb = GetComponent<Rigidbody2D>();
        currentSpeed = matchConfig.InitialSpeed;
    }

    public void ResetBallPosition()
    {
        transform.position = initialBallPosition;
    }
    public void LaunchBall()
    {
        isActive = true;
        float randomAngle = Random.Range(-matchConfig.MaxAngle, matchConfig.MaxAngle) * Mathf.Deg2Rad;
        int randomHorizontalDir = Random.Range(0, 2) == 0 ? -1 : 1;

        float xComponent = Mathf.Cos(randomAngle) * randomHorizontalDir;
        float yComponent = Mathf.Sin(randomAngle);

        Vector2 direction = new Vector2(xComponent, yComponent).normalized;
        rb.linearVelocity = direction * currentSpeed;
    }

    public void DisableBall()
    {
        isActive = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
    }
}

