using UnityEngine;
using TMPro;

public class UI : MonoBehaviour
{
    public TMP_Text ScoreText;
    public CanvasGroup StartScreenCanvasGroup;
    public CanvasGroup GameOverScreenCanvasGroup;
    public TMP_Text TimeText;
    public GameTimer GameTimer;

    public void ShowScore()
    {
        ScoreText.text = "Score: " + ScoreKeeper.GetScore();
    }

    public void ResetScore()
    {
        ScoreText.text = "Score: 0";
    }

    public void HideStartScreen()
    {
        CanvasGroupDisplayer.Hide(StartScreenCanvasGroup);
    }
    public void ShowStartScreen()
    {
        CanvasGroupDisplayer.Show(StartScreenCanvasGroup);
    }
    public void HideGameOverScreen()
    {
        CanvasGroupDisplayer.Hide(GameOverScreenCanvasGroup);
    }
    public void ShowGameOverScreen()
    {
        CanvasGroupDisplayer.Show(GameOverScreenCanvasGroup);
    }
    public void ShowTime()
    {
        TimeText.text = GameTimer.GetTimeAsString();
    }
    
}
