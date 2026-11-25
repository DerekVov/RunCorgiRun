using UnityEngine;
using TMPro;

public class UI : MonoBehaviour
{
    public TMP_Text ScoreText;

    public void ShowScore()
    {
        ScoreText.text = "Score: " + ScoreKeeper.GetScore();
    }
}
