using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_PauseMenu : MonoBehaviour
{
    [SerializeField]
    private GameObject pausePanel;

    [SerializeField]
    private Button exitButton;

    private bool isPause = false;

    private void Awake()
    {
        
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.P))
        {
            TogglePause();

            if(!pausePanel.activeSelf)
            {
                pausePanel.SetActive(true);
            }
        } else
        {
            pausePanel.SetActive(false);
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
