using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class StartGameVideo : MonoBehaviour
{
    public VideoPlayer video;
    public AudioClip Music;
    public string videoFileName;

    void Start()
    {
        PlayVideo();
        SoundManager.Instance.PlayMusic(Music);
    }

    private void StartGame(VideoPlayer source)
    {
        SceneManagerObject.Instance.LoadNextScene();
    }

    private void OnDisable()
    {
        video.loopPointReached -= StartGame;
    }

    private void PlayVideo()
    {
        VideoPlayer video = GetComponent<VideoPlayer>();

        if (video)
        {
            string videoPath = System.IO.Path.Combine(Application.streamingAssetsPath, videoFileName);
            Debug.Log(videoPath);
            video.url = videoPath;
            video.Play();
            video.loopPointReached += StartGame;
        }
    }
}
