using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UI_MainMenu : MonoBehaviour
{
    [SerializeField]
    private Button settingsButton;

    [SerializeField]
    private GameObject settingsPanel;

    [SerializeField]
    private GameObject menuPanel;

    private void Awake()
    {
        settingsButton.onClick.AddListener(OnSettingsButtonClicked);
    }

    public void StartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void ExitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }

    public void OnDestroy()
    {
        settingsButton.onClick.RemoveAllListeners();
    }

    private void OnSettingsButtonClicked()
    {
        if(!settingsPanel.activeSelf)
        {
            settingsPanel.SetActive(true);
            menuPanel.SetActive(false);
        }
    }
}
