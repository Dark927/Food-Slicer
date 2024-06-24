using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AudioManager : MonoBehaviour
{
    // -------------------------------------------------------------------------
    // Parameters
    // -------------------------------------------------------------------------

    #region Parameters

    [Header("Music Settings")]
    [Space]

    [SerializeField] AudioSource musicSource;
    [SerializeField] Slider musicVolumeSlider;
    [SerializeField] TextMeshProUGUI musicVolumeText;

    [Header("Effects Settings")]
    [Space]

    [SerializeField] AudioSource soundsSource;
    [SerializeField] Slider soundsVolumeSlider;
    [SerializeField] TextMeshProUGUI soundsVolumeText;

    #endregion

    // -------------------------------------------------------------------------
    // Private Methods
    // -------------------------------------------------------------------------

    #region Private Methods 

    private void Update()
    {
        UpdateVolume(musicSource, musicVolumeSlider, musicVolumeText);
        UpdateVolume(soundsSource, soundsVolumeSlider, soundsVolumeText);
    }

    private void UpdateVolume(AudioSource volumeSource, Slider volumeSlider, TextMeshProUGUI volumeText = null)
    {
        volumeSource.volume = volumeSlider.value / 100;

        if (volumeText != null)
        {
            volumeText.text = volumeSlider.value.ToString() + '%';
        }
    }


    public void PlaySound(AudioClip sound)
    {
        soundsSource.PlayOneShot(sound);
    }

    #endregion
}
