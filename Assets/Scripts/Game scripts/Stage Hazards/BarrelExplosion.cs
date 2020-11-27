using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrelExplosion : MonoBehaviour
{
    public int damage = 3;
    private GameController gameController;

    // Use this for initialization
    void Start()
    {
        GameObject gameControllerObject = GameObject.FindWithTag("GameController");
        if (gameControllerObject != null)
        {
            gameController = gameControllerObject.GetComponent<GameController>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player1")
        {
            gameController.player1HP -= damage;
        }
        if (other.tag == "Player2")
        {
            gameController.player2HP -= damage;
        }
    }
}
