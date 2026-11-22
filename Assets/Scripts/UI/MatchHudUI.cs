using UnityEngine;

public class MatchHudUI : MonoBehaviour
{
    [SerializeField] private MatchController matchController;

    private void Awake()
    {
        matchController.OnScoreChanged += OnPointsChange;
    }

    public void OnPointsChange()
    {
        
    }
}
