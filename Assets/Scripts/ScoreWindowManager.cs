using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreWindowManager : MonoBehaviour
{
    public Text currentScoreText;

    public Text bestScoreText;

    public GameObject scoreWindow;

    private void Awake()
    {
        scoreWindow.SetActive(false);
    }

    public void OpenScoreWindow(int score, int bestScore)
    {
        if (scoreWindow != null)
        {
            scoreWindow.SetActive(true);
            currentScoreText.text = score.ToString();
            bestScoreText.text = bestScore.ToString();
        }
    }

    public void CloseScoreWindow()
    {
        if (scoreWindow != null)
        {
            scoreWindow.SetActive(false);
        }
    }
}
