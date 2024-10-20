using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuManager : MonoBehaviour
{
    [SerializeField]
    private Button playButton;

    [SerializeField]
    private GameObject mainMenuPanel;

    private bool isPause = true;

    private void Awake()
    {
        playButton.onClick.AddListener(OnPlayButtonClicked);
    }

    void Start()
    {
        Time.timeScale = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePause();

            if(!mainMenuPanel.activeSelf)
            {
                mainMenuPanel.SetActive(true);
                mainMenuPanel.transform.GetChild(0).gameObject.SetActive(true);

            } else if(mainMenuPanel.activeSelf)
            {
                mainMenuPanel.SetActive(false);
                mainMenuPanel.transform.GetChild(0).gameObject.SetActive(true);
            }
        }
    }

    private void OnDestroy()
    {
        playButton.onClick.RemoveAllListeners();
    }

    private void OnPlayButtonClicked()
    {
        if(mainMenuPanel.activeSelf)
        {
            TogglePause();
            mainMenuPanel.SetActive(false);
            mainMenuPanel.transform.GetChild(0).gameObject.SetActive(false);
        }
    }

    private void TogglePause()
    {
        if(isPause)
        {
            Time.timeScale = 1;
            isPause = false;

        } else
        {
            Time.timeScale = 0;
            isPause = true;
        }
    }
}
