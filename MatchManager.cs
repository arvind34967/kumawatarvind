using UnityEngine;

public class MatchManager : MonoBehaviour
{
    public static MatchManager Instance;

    [Header("Match Settings")]
    public int totalOvers = 5;
    public int totalWickets = 10;

    [Header("Current Match Stats")]
    public int currentRuns = 0;
    public int currentWickets = 0;
    public int totalBallsBowled = 0;

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    public void AddRuns(int runs)
    {
        currentRuns += runs;
        Debug.Log($"Runs Scored: {runs} | Total: {currentRuns}/{currentWickets}");
    }

    public void AddWicket()
    {
        currentWickets++;
        Debug.Log($"WICKET! | Total: {currentRuns}/{currentWickets}");
        if (currentWickets >= totalWickets)
        {
            EndInnings();
        }
    }

    public void OnBallBowled()
    {
        totalBallsBowled++;
        if (totalBallsBowled % 6 == 0)
        {
            Debug.Log($"Over Complete! {totalBallsBowled / 6} Overs done.");
        }
    }

    private void EndInnings()
    {
        Debug.Log("Innings Ended!");
    }
}