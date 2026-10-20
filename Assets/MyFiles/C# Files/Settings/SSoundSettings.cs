using System;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SSoundSettings : MonoBehaviour
{
    [SerializeField] private AudioMixer mAudioMixer;
    [SerializeField] private Slider mMasterSlider;
    [SerializeField] private Slider mMusicSlider;
    [SerializeField] private Slider mSFXSlider;
    
    [Header("Keys")]
    [SerializeField] private String master = "Master";
    [SerializeField] private String music = "Music";
    [SerializeField] private String sfx = "SFX";
    
    
    void Start()
    {
        if (PlayerPrefs.HasKey("Master"))
        {
            LoadVolume();
        }
        else
        {
            SetMaster();
            SetMusicVolume();
            SetSFXVolume();
        }
    }

    private void LoadVolume()
    {
        mMasterSlider.value = PlayerPrefs.GetFloat(master);
        mMusicSlider.value = PlayerPrefs.GetFloat(music);
        mSFXSlider.value = PlayerPrefs.GetFloat(sfx);
        
        SetMaster();
        SetMusicVolume();
        SetSFXVolume();
        
    }
    public void SetMaster()
    {
        float vol = mMasterSlider.value;
        mAudioMixer.SetFloat(master, Mathf.Log10(vol) * 20);
        PlayerPrefs.SetFloat(master, vol);
    }

    public void SetMusicVolume()
    {
        float vol = mMusicSlider.value;
        mAudioMixer.SetFloat(music, Mathf.Log10(vol) * 20);
        PlayerPrefs.SetFloat(music, vol);
    }

    public void SetSFXVolume()
    {
        float vol = mSFXSlider.value;
        mAudioMixer.SetFloat(sfx, Mathf.Log10(vol) * 20);
        PlayerPrefs.SetFloat(sfx, vol);
    }

}
