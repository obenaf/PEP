using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueStarter : MonoBehaviour
{
    private GameObject DialogueCanvas;
    void Start() {
        DialogueCanvas = GameObject.Find("DialogueCanvas");
        DialogueCanvas.SetActive(false);
    }
    void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Player")) {
            DialogueCanvas.SetActive(true);
        }
    }
    void OnTriggerExit2D(Collider2D other) {
        if(other.CompareTag("Player")) {
            DialogueCanvas.SetActive(false);
        }
    }
}
