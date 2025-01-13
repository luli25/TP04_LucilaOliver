using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolumeSettings : MonoBehaviour
{
    [SerializeField]
    private AudioMixer mixer;

    [SerializeField]
    private Slider musicSlider;

    [SerializeField]
    private Slider fxSlider;

    [SerializeField]
    private Slider masterSlider;

    [SerializeField]
    private Button back;

    [SerializeField]
    private GameObject menuPanel;

    [SerializeField]
    private GameObject settingsPanel;

    private void Awake()
    {
        back.onClick.AddListener(OnBackButtonClicked);
    }

    private void Start()
    {
        SetMusicVolume();
    }

    public void SetMusicVolume()
    {
        float musicVolume = musicSlider.value;
        mixer.SetFloat("music", Mathf.Log10(musicVolume) * 20);
    }

    public void SetFXVolume()
    {
        float fxVolume = fxSlider.value;
        mixer.SetFloat("fx", Mathf.Log10(fxVolume) * 20);
    }

    public void SetMasterVolume()
    {
        float masterVolume = masterSlider.value;
        mixer.SetFloat("master", Mathf.Log10(masterVolume) * 20);
    }

    private void OnDestroy()
    {
       back.onClick.RemoveAllListeners();
    }

    private void OnBackButtonClicked()
    {
        if (!menuPanel.activeSelf)
        {
            menuPanel.SetActive(true);
            settingsPanel.SetActive(false);
        }
    }
}
