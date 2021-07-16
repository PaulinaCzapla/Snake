using UnityEngine.UI;
using UnityEngine;
using UnityEngine.EventSystems;
using System.IO;
using System.Text;

public class GameManager : MonoBehaviour
{
    private int currentScore;

    private int bestScore;

    private string path;

    public Snake snake;

    public Apple apple;

    public Text currentScoreText;

    public Text bestScoreText;

    public ScoreWindowManager scoreWindow;


    private void Awake()
    {
        currentScore = 0;
        path = "bestscore.txt";
        ReadFile();
        SetScoreText(ref currentScoreText, currentScore);
        SetScoreText(ref bestScoreText, bestScore);
        scoreWindow.CloseScoreWindow();
    }
    private void SetScoreText(ref Text text, int score) => text.text = score.ToString();

    private void PauseGame() => Time.timeScale = 0f;

    private void ResumeGame() => Time.timeScale = 1f;

    private void ReadFile()
    {
        if (File.Exists(path))
        {
            using (FileStream fs = File.OpenRead(path))
            {
                string score = string.Empty;
                byte[] b = new byte[1024];
                UTF8Encoding temp = new UTF8Encoding(true);

                while (fs.Read(b, 0, b.Length) > 0)
                {
                    score += temp.GetString(b);
                }

                int.TryParse(score, out bestScore);
            }
        }
    }

    private void SaveFile()
    {
        using (FileStream fs = File.Create(path))
        {
            byte[] info = new UTF8Encoding(true).GetBytes(bestScore.ToString());
            fs.Write(info, 0, info.Length);
        }
    }

    public void PlayerScores()
    {
        snake.Grow();
        apple.RandomizePosition();

        ++currentScore;
        SetScoreText(ref currentScoreText, currentScore);
    }

    public void PlayerLoses()
    {
        if (snake.length > 3 || snake.transform.position.x != 0 || snake.transform.position.y != 0)
        {
            scoreWindow.OpenScoreWindow(currentScore, bestScore);
            PauseGame();

            if (currentScore > bestScore)
            {
                bestScore = currentScore;
                SetScoreText(ref bestScoreText, currentScore);
            }

            SaveFile();
        }
    }

    public void PlayAgain()
    {
        ResumeGame();
        snake.ResetState();
        currentScore = 0;
        SetScoreText(ref currentScoreText, currentScore);
        scoreWindow.CloseScoreWindow();
    }

    public void QuitGame() => Application.Quit();

}
