using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    [SerializeField]
    private TMP_Text scoreText;

    [SerializeField]
    private GameObject gameOverPanel;

    private float score = 0f;

    private float pointsPerSeconds = 1f;

    public static GameManager Instance {  get; private set; }

    private void Awake()
    {
        if(Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }

    private void Update()
    {
        UpdateScore();
    }

    public void UpdateScore()
    {
        score += pointsPerSeconds;
        scoreText.text = score.ToString();
    }

    public void ShowGameOverUI()
    {
        gameOverPanel.SetActive(true);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        score = 0f;
        Time.timeScale = 1f;
    }
}
