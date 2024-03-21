using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagerObject : MonoBehaviour
{
    public static SceneManagerObject Instance;
    [SerializeField] private float timeBtwnSceneTransitions;

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
    }

    public void LoadScene(int sceneIndex)
    {
        StartCoroutine(ChangeSceneCoroutine(sceneIndex));
    }

    public void LoadNextScene()
    {
        StartCoroutine(ChangeSceneCoroutine(SceneManager.GetActiveScene().buildIndex + 1));
    }

    public void ReloadScene()
    {
        StartCoroutine(ChangeSceneCoroutine(SceneManager.GetActiveScene().buildIndex));
    }

    public IEnumerator ChangeSceneCoroutine(int sceneIndex)
    {
        SceneTransitionUI.Instance.ExitScene();

        yield return new WaitForSeconds(timeBtwnSceneTransitions);

        SceneManager.LoadScene(sceneIndex);
    }
}
