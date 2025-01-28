using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    [SerializeField]
    private TMP_Text scoreText;

    [SerializeField]
    private GameObject gameOverPanel;

    [SerializeField]
    private float initialScrollSpeed;

    private int score = 0;
    private float timer;
    private float scrollSpeed;

    public static GameManager Instance { get; private set; }

    private void Awake()
    {
        if (Instance != null && Instance != this)
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
        UpdateSpeed();
    }

    public void UpdateScore()
    {
        int pointsPerSecond = 10;

        timer += Time.deltaTime;
        score = (int)(timer * pointsPerSecond);

        scoreText.text = string.Format("{0:00000}", score);

    }

    public void ShowGameOverUI()
    {
        gameOverPanel.SetActive(true);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        score = 0;
        Time.timeScale = 1f;
    }

    public float GetScrollSpeed()
    {
        return scrollSpeed;
    }

    public void UpdateSpeed()
    {
        float speedDivider = 10f;
        scrollSpeed = initialScrollSpeed + timer / speedDivider;
    }
}
