using UnityEngine;

[CreateAssetMenu(fileName = "MatchConfig", menuName = "Pong/MatchConfig")]
public class MatchConfigSO : ScriptableObject
{
    [SerializeField] private float initialSpeed = 10f;
    [SerializeField] private float maxSpeed = 15f;
    [SerializeField] private float speedIncrement = 1f;
    [SerializeField] private float maxAngle = 45f;

    public float InitialSpeed => initialSpeed;
    public float MaxSpeed => maxSpeed;
    public float SpeedIncrement => speedIncrement;
    public float MaxAngle => maxAngle;

}
