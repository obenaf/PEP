using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelControl : MonoBehaviour
{
    public int index;
    void OnTriggerEnter2D(Collider2D other) {
        Debug.Log("Exit triggered");
        Debug.Log(index);
        if (other.CompareTag("Player")) {
            Debug.Log("Enter next scene load");
            SceneManager.LoadScene(index);
        }
    }
}
