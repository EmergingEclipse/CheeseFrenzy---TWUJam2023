using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class Settings : MonoBehaviour
{
    [SerializeField] private Slider volumeSlider = null;

    [SerializeField] TMP_Text VolumeTextUI = null;

    void Start()
    {
        LoadValues();
    }
    public void VolumeSlider(float volume)
    {
        VolumeTextUI.text = volume.ToString("0.0");

    }
    public void SaveVolumeButton()
    {
        float volumeValue = volumeSlider.value;
        PlayerPrefs.SetFloat("VolumeValue", volumeValue);
        LoadValues();

    }

    void LoadValues()
    {
        float volumeValue = PlayerPrefs.GetFloat("VolumeValue");
        volumeSlider.value = volumeValue;
        AudioListener.volume = volumeValue;
    }


}
