using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Tutorial : MonoBehaviour
{
    public Canvas tutorialMessage;
    bool isTrigger = false;

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Player") && isTrigger == false)
        {
            tutorialMessage.gameObject.SetActive(true);
            isTrigger = true;
        }
    }

    // private void OnTriggerExit2D(Collider2D other) {
    //     isTrigger = false;
    // }

    public void OffTutorial(){
        tutorialMessage.gameObject.SetActive(false);
        isTrigger = true;
    }

}
