public class MatchRules
{
    private int playerOneGoals = 0;
    private int playerTwoGoals = 0;
    private int targetGoals = 5;
    private string winner = null;

    public int PlayerOneGoals => playerOneGoals;
    public int PlayerTwoGoals => playerTwoGoals;
    public int TargetGoals => targetGoals;
    public string Winner => winner;
    public void SetWinner(bool isPlayerOne)
    {
        winner = isPlayerOne ? "Player One" : "Player Two";
    }

    public void AddPlayerGoal(bool isPlayerOne)
    {
        if (isPlayerOne)
        {
            playerOneGoals++;
            if(playerOneGoals >= targetGoals)
            {
                SetWinner(isPlayerOne);
            }
        }
        else
        {
            playerTwoGoals++;
            if(playerTwoGoals >= targetGoals)
            {
                SetWinner(isPlayerOne);
            }
        }
    }

    public void ResetMatch()
    {
        playerOneGoals = 0;
        playerTwoGoals = 0;
        winner = null;
    }
}
