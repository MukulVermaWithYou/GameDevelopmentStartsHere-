using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Score : MonoBehaviour
{
    public Text scoreBoard;
    public Player playerData;

    // Update is called once per frame
    void Update()
    {
        scoreBoard.text = "Coins: " + playerData.coinsCollected;
    }

}


