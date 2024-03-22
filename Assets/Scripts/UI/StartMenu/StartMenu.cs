using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    public AudioClip Music, startGameFx;
    private void Start() {
        SoundManager.Instance.PlayMusic(Music);
        
    }

    public void StartGame()
    {
        SoundManager.Instance.PlaySoundFx(startGameFx);
        SceneManagerObject.Instance.LoadNextScene();
        SoundManager.Instance.StopMusic();
    }

}
