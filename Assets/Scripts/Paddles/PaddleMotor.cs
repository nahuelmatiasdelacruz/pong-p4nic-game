using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(BoxCollider2D))]
public class PaddleMotor : MonoBehaviour
{
    [SerializeField] private float movementSpeed = 5f;
    private BoxCollider2D paddleCollider;
    [SerializeField] private BoxCollider2D topWallCollider;
    [SerializeField] private BoxCollider2D bottomWallCollider;
    private float topWallLowerPosition;
    private float bottomWallUpperPosition;
    private float paddleHalfSize;
    private float maxY;
    private float minY;
    private Vector2 paddleInitialPosition;
    private IPaddleInput paddleInput;
    private Rigidbody2D rb;
    
    private void Awake()
    {
        paddleInput = GetComponent<IPaddleInput>();
        rb = GetComponent<Rigidbody2D>();
        paddleCollider = GetComponent<BoxCollider2D>();
    }
    private void Start()
    {
        paddleInitialPosition = transform.position;
        topWallLowerPosition = topWallCollider.bounds.min.y;
        bottomWallUpperPosition = bottomWallCollider.bounds.max.y;
        paddleHalfSize = paddleCollider.bounds.extents.y;
        maxY = topWallLowerPosition - paddleHalfSize;
        minY = bottomWallUpperPosition + paddleHalfSize;
    }
    private void FixedUpdate()
    {
        MovePaddle();
    }

    private void MovePaddle()
    {
        float verticalIntent = paddleInput.VerticalIntent();

        if(verticalIntent == 0) return;

        float paddlePositionX = rb.position.x;
        float paddlePositionY = rb.position.y;

        float finalYposition = Mathf.Clamp(paddlePositionY+(verticalIntent * Time.fixedDeltaTime * movementSpeed),minY,maxY);

        Vector2 finalPosition = new Vector2(paddlePositionX,finalYposition);
        rb.MovePosition(finalPosition);
    }

    public void ResetPaddlePosition() => transform.position = paddleInitialPosition;

}
