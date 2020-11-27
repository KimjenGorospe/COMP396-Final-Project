using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flamethrower2 : MonoBehaviour
{
    public float speed = 1;
    public GameObject explosion;
    public int damage = 1;
    private Rigidbody2D rBody;
    private GameController gameController;

    //[Header("Sounds")]
    //public AudioSource flam;
    // Start is called before the first frame update
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
        Debug.Log(gameController.player1HP);

        if (other.tag == "Player")
        {
            //flam.Play();
            Debug.Log(gameController.player1HP);
            gameController.player1HP -= damage;
            Instantiate(explosion, this.transform.position, this.transform.rotation);
            Debug.Log(gameController.player1HP);
            Destroy(this.gameObject);
        }
        if (other.tag == "Wall")
        {
            //flam.Play();
            Debug.Log(gameController.player1HP);
            Instantiate(explosion, this.transform.position, this.transform.rotation);
            Destroy(this.gameObject);
        }
    }
}
