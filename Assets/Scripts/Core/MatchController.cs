using System;
using System.Collections;
using UnityEngine;

public class MatchController : MonoBehaviour
{
    [SerializeField] MatchConfigSO matchConfig;
    [SerializeField] BallController ballController;
    [SerializeField] GoalZone leftGoalZone;
    [SerializeField] GoalZone rightGoalZone;
    private MatchRules matchRules;
    private MatchState matchState = MatchState.MainMenu;
    public MatchState MatchState => matchState;
    public event Action OnMatchStarted;
    public event Action OnMatchStateChanged;
    public event Action OnMatchEnded;
    public event Action OnScoreChanged;

    private void Awake()
    {
        leftGoalZone.OnGoal += OnGoal;
        rightGoalZone.OnGoal += OnGoal;
        matchRules = new MatchRules();
    }

    private void Start()
    {
        StartCoroutine(StartGame());
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
