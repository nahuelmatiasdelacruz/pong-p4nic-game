using System;
using UnityEngine;

public class GoalZone : MonoBehaviour
{
    [SerializeField] private bool isPlayerOne;

    public event Action<bool> OnGoal;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            OnGoal?.Invoke(isPlayerOne);
        }
    }
}
