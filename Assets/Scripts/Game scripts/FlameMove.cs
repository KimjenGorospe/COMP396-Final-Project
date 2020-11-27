using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlameMove : MonoBehaviour
{
    public float speed;
    public GameObject explosion;
    public int damage;
    private Rigidbody2D rBody;
    private GameController gameController;


    // Use this for initialization
    void Start()
    {
        GameObject gameControllerObject = GameObject.FindWithTag("GameController");
        if (gameControllerObject != null)
        {
            gameController = gameControllerObject.GetComponent<GameController>();
        }
        rBody = GetComponent<Rigidbody2D>();
        rBody.velocity = transform.right * speed;
    }

    // Update is called once per frame
    void Update()
    {
    }

    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.tag == "Player")
        {
            gameController.player1HP -= damage;
            Instantiate(explosion, this.transform.position, this.transform.rotation);
            Destroy(this.gameObject);
        }

        if (other.tag == "Player2")
        {
            gameController.player2HP -= damage;
            Instantiate(explosion, this.transform.position, this.transform.rotation);
            Destroy(this.gameObject);
        }
        if (other.tag == "Wall")
        {
            Instantiate(explosion, this.transform.position, this.transform.rotation);
            Destroy(this.gameObject);
        }
    }
}
