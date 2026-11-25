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
        inputSystem.UI.Pause.performed += OnPausePressed;
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

    private void OnPausePressed(InputAction.CallbackContext ctx)
    {
        if(matchState == MatchState.Playing)
        {
            matchState = MatchState.Paused;
            Time.timeScale = 0f;
        }else if(matchState == MatchState.Paused)
        {
            matchState = MatchState.Playing;
            Time.timeScale = 1f;
        }
    }

    private void OnGoal(bool isPlayerOne)
    {
        matchRules.AddPlayerGoal(isPlayerOne);
        OnScoreChanged?.Invoke();
        if(matchRules.Winner != null)
        {
            matchState = MatchState.GameOver;
            OnMatchEnded?.Invoke();
            ballController.ResetBallPosition();
        }
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
