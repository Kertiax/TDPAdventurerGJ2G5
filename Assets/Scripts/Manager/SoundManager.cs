using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance;

    [SerializeField] private AudioSource musicAudioSource;
    [SerializeField] private AudioSource soundFxAudioSource;
    [SerializeField] private AudioMixer masterAudioMixer;
    [SerializeField] private AudioClip altarSound;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this);
        }
        else
        {
            Destroy(gameObject);
        }

        SetInitialVolume();
    }

    private void SetInitialVolume()
    {
        masterAudioMixer.SetFloat("MusicVolume", PlayerPrefs.GetFloat("MusicVolume", 0f));
        masterAudioMixer.SetFloat("SoundFXVolume", PlayerPrefs.GetFloat("SoundFxVolume", 0f));
    }

    public void PlaySoundFx(AudioClip audioClip)
    {
        soundFxAudioSource.PlayOneShot(audioClip);
    }

    public void PlayMusic(AudioClip musicClip)
    {
        musicAudioSource.clip = musicClip;
        musicAudioSource.Play();
    }

    public void StopMusic()
    {
        musicAudioSource.Stop();
    }

    public void ChangeMusicVolume(float volume)
    {
        masterAudioMixer.SetFloat("MusicVolume", PlayerPrefs.GetFloat("MusicVolume", 0f));
        PlayerPrefs.SetFloat("MusicVolume", volume);
    }

    public void ChangeSoundFxVolume(float volume)
    {
        masterAudioMixer.SetFloat("SoundFXVolume", PlayerPrefs.GetFloat("SoundFxVolume", 0f));
        PlayerPrefs.SetFloat("SoundFxVolume", volume);
    }

    public void AltarSound()
    {
        PlaySoundFx(altarSound);
    }
}
