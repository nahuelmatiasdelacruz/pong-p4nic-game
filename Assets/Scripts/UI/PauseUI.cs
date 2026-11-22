using UnityEngine;

public class PauseUI : MonoBehaviour
{
    [SerializeField] private MatchController matchController;

    private void Awake()
    {
        matchController.OnMatchPaused += OnGamePaused;
    }

    private void OnGamePaused()
    {
        
    }
}
