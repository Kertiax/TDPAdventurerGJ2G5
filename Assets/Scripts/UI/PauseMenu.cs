using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool gameIsPaused = false;
    public GameObject pauseMenuUi;


    public void Pause()
    {
        pauseMenuUi.SetActive(true);
        Time.timeScale = 0f;
        gameIsPaused = true;
    }

    public void Resume()
    {
        pauseMenuUi.SetActive(false);
        Time.timeScale = 1f;
        gameIsPaused = false;
    }

    public void Restart()
    {
        Resume();
        SceneManagerObject.Instance.ReloadScene();
    }

    public void MainMenu()
    {
        Resume();
        SceneManagerObject.Instance.LoadScene(0);
    }

    public void SfxVolume(float volume)
    {
        SoundManager.Instance.ChangeSoundFxVolume(volume);
    }

    public void MusicVolume(float volume)
    {
        SoundManager.Instance.ChangeMusicVolume(volume);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (gameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }
}

