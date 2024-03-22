using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class StartGameVideo : MonoBehaviour
{
    public VideoPlayer video;
    public AudioClip Music;
    
    void Start()
    {
        video.loopPointReached += StartGame;
        SoundManager.Instance.PlayMusic(Music);
    }

    private void StartGame(VideoPlayer source)
    {
        SceneManagerObject.Instance.LoadNextScene();
    }

    private void OnDisable() {
        video.loopPointReached -= StartGame;
    }
}
