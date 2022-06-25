using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CoinPicker : MonoBehaviour {
    private float coinAmount = 0;

    public TextMeshProUGUI coinText;

    private void OnTriggerEnter2D (Collider2D other) {
        if (other.gameObject.tag == "Coin") {
            coinAmount++;
            coinText.text = coinAmount.ToString ();
            Destroy (other.gameObject);
        }
    }
}