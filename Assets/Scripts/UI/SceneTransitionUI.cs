using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneTransitionUI : MonoBehaviour
{
    public static SceneTransitionUI Instance;
    [SerializeField] private CanvasGroup fadeEffect;
    [SerializeField] private float timeFade;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        EnterScene();
    }

    public void EnterScene()
    {
        LeanTween.alphaCanvas(fadeEffect, 0, timeFade).setEase(LeanTweenType.easeInCirc).setOnComplete(DisableInteractableObjects);
    }

    public void ExitScene()
    {
        LeanTween.alphaCanvas(fadeEffect, 1, timeFade).setOnComplete(EnableInteractableObjects);
    }

    private void DisableInteractableObjects()
    {
        fadeEffect.interactable = false;
        fadeEffect.blocksRaycasts = false;
    }

    private void EnableInteractableObjects()
    {
        fadeEffect.interactable = true;
        fadeEffect.blocksRaycasts = true;
    }
}
