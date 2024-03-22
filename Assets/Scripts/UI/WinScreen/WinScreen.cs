using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinScreen : MonoBehaviour
{
    public AudioClip Music, startGameFx;
    private void Start()
    {
        SoundManager.Instance.PlayMusic(Music);

    }

    public void Restart()
    {
        SoundManager.Instance.PlaySoundFx(startGameFx);
        SceneManagerObject.Instance.LoadScene(0);
        SoundManager.Instance.StopMusic();
    }
}
