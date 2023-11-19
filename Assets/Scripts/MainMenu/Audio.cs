using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class Audio : MonoBehaviour
{
    [SerializeField] private AudioMixer mixer;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioMixMode mixMode;
    [SerializeField] private Slider audioSlider;
    public void OnChangeSlider(float value)
    {
        switch (mixMode)
        {
            case AudioMixMode.LinearAudioSourceVolume:
                audioSource.volume = value; 
                break;
            case AudioMixMode.LinearMixerVolume:
                mixer.SetFloat("Volume", (-80 + value * 100));
                break;
            case AudioMixMode.LogrithmicMixerVolume:
                mixer.SetFloat("Volume", Mathf.Log10(value) * 20);
                break;
        }
        PlayerPrefs.SetFloat("Volume", value);
        PlayerPrefs.Save();
    }

    private void Start()
    {
        float volume = PlayerPrefs.GetFloat("Volume", 1);
        mixer.SetFloat("Volume", Mathf.Log10(volume) * 20);
        audioSlider.value = volume;
    }
    public enum AudioMixMode
    {
        LinearAudioSourceVolume,
        LinearMixerVolume,
        LogrithmicMixerVolume
    }
}
