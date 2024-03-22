using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalDoor : MonoBehaviour
{
    [SerializeField] private bool startNextLevel = false;
    [SerializeField] private int sceneIndexToLoad;

    public AudioClip finalGateSound;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent(out PlayerMovement player))
        {
            player.StopPlayer();
            LoadLevel();
        }
    }

    private void LoadLevel()
    {
        SoundManager.Instance.PlaySoundFx(finalGateSound);
        if (startNextLevel)
        {
            SceneManagerObject.Instance.LoadNextScene();
        }
        else    
        {
            SceneManagerObject.Instance.LoadScene(sceneIndexToLoad);
        }
    }
}
