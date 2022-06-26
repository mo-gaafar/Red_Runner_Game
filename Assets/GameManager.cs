using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {
    bool gameHasEnded = false;
    public GameOverScreen gameOverScreen;
    public float restartDelay = 2f;
    float coinAmount = 0;

    public void EndGame () {

        if (!gameHasEnded) {
            gameHasEnded = true;
            Debug.Log ("GAME OVER");
            coinAmount = FindObjectOfType<CoinPicker> ().GetAmountOfCoins ();
            gameOverScreen.ShowGameOverScreen (coinAmount);
            //Restart game
            // Invoke ("Restart", restartDelay); //1 second delay before calling RestartGame
        }

    }

    public void LevelUp () {
        coinAmount = FindObjectOfType<CoinPicker> ().GetAmountOfCoins ();
        if (coinAmount > 20) {
            SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex + 1);
        }
    }

    public void Restart () {
        Debug.Log ("Game Restart");
        SceneManager.LoadScene (SceneManager.GetActiveScene ().name);
    }

    public void MainMenu () {
        Debug.Log ("Main Menu");
        SceneManager.LoadScene ("Menu");
    }
}