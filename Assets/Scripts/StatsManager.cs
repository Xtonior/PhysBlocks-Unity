using UnityEngine;
using TMPro;

public class StatsManager : MonoBehaviour
{
    [SerializeField] private TMP_Text scoreText;

    public int Score { get; private set; }
    public int StepNum { get; private set; } = 1;

    public void AddStep()
    {
        StepNum++;
    }

    public void AddPoint(int point)
    {
        Score += Mathf.RoundToInt(point / StepNum);

        scoreText.text = "Score: " + Score.ToString();
    }
}
