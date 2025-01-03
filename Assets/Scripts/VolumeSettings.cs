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
}
