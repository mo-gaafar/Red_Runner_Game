using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour {
    private void OnCollisionEnter2D (Collision2D other) {
        if (other.gameObject.tag == "Boundary") {
            FindObjectOfType<GameManager> ().EndGame ();
        }
        if (other.gameObject.tag == "LevelUp") {
            FindObjectOfType<GameManager> ().LevelUp ();
        }
        if (other.gameObject.tag == "Enemy") {
            FindObjectOfType<GameManager> ().EndGame ();
        }
    }
}