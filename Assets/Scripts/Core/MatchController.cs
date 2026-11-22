using System;
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class MatchController : MonoBehaviour
{
    [SerializeField] MatchConfigSO matchConfig;
    [SerializeField] BallController ballController;
    [SerializeField] GoalZone leftGoalZone;
    [SerializeField] GoalZone rightGoalZone;
    private Input_System_Actions inputSystem;
    private MatchRules matchRules;
    private MatchState matchState = MatchState.MainMenu;
    public MatchState MatchState => matchState;
    public event Action OnMatchStarted;
    public event Action OnMatchStateChanged;
    public event Action OnMatchPaused;
    public event Action OnMatchEnded;
    public event Action OnScoreChanged;

    private void Awake()
    {
        inputSystem = new Input_System_Actions();
        leftGoalZone.OnGoal += OnGoal;
        rightGoalZone.OnGoal += OnGoal;
        matchRules = new MatchRules();
    }

    private void OnEnable()
    {
        inputSystem.UI.Pause.performed += OnGamePaused;
        inputSystem.UI.Enable();
    }

    private void OnDisable()
    {
        inputSystem.UI.Disable();
    }

    private void Start()
    {
        StartCoroutine(StartGame());
    }

    private void OnGamePaused(InputAction.CallbackContext ctx)
    {
        matchState = MatchState.Paused;
        Debug.Log("Pausa!");
        Time.timeScale = 0f;
    }

    private void OnGoal(bool isPlayerOne)
    {
        matchRules.AddPlayerGoal(isPlayerOne);
    }

    private IEnumerator StartGame()
    {
        matchState = MatchState.Playing;
        yield return new WaitForSeconds(3f);
        ballController.LaunchBall();
    }

    private void ResetGame()
    {
        matchRules.ResetMatch();
        ballController.ResetBallPosition();
        StartCoroutine(StartGame());
    }
}
