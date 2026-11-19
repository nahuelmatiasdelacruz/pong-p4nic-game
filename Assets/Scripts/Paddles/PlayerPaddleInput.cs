using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerPaddleInput : MonoBehaviour, IPaddleInput
{
    [SerializeField] private bool isLeftPaddle = false;
    private Input_System_Actions inputSystem;

    private void Awake()
    {
        inputSystem = new Input_System_Actions();
    }

    private void OnEnable()
    {
        inputSystem.Enable();
    }

    private void OnDisable()
    {
        inputSystem.Disable();
    }

    public float VerticalIntent() => isLeftPaddle ? inputSystem.Players.LeftPaddle.ReadValue<float>() : inputSystem.Players.RightPaddle.ReadValue<float>();
    
}
