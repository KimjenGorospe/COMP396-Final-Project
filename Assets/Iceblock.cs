using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Iceblock : MonoBehaviour
{
    public GameController gameController;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("Player 1 was caught lackin");
            gameController.player1HP -= 10.0f;
        }
    }
}
