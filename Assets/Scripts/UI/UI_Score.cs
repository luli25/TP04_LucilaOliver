using UnityEngine;
using TMPro;
using UnityEngine.SocialPlatforms;

public class UI_Score : MonoBehaviour
{
    [SerializeField]
    private TMP_Text scoreText;

    private float score = 0f;

    private float pointsPerSeconds = 1f;

    private void Update()
    {
        UpdateScore();
    }

    private void UpdateScore()
    {
        score += pointsPerSeconds;
        scoreText.text = score.ToString();
    }
}
