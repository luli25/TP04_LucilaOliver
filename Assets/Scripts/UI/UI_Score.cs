using UnityEngine;
using TMPro;

public class UI_Score : MonoBehaviour
{
    public TMP_Text scoreText;

    public void UpdateScore(int score)
    {
        score++;
        scoreText.text = score.ToString();
    }
}
