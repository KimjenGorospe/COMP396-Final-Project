using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2FMController : MonoBehaviour
{
    [Header("Movement Settings 2")]
    public float speed = 1.5f;
    private Vector2 movement;
    private Vector2 fixedMovement;
    private float horiz;
    private float vert;
    private bool canMove = true;

    [Header("Attack Settings 2")]
    public GameObject laser2;
    public GameObject LaserSpawn2Right;
    public float fireRate = 1f;
    private Rigidbody2D rBody;

    private float timer = 0.0f;
    private float myTime = 0.0f;
    private GameController gameController;

    [Header("Sounds")]
    public AudioSource lasr;

    // Use this for initialization
    void Start()
    {
        GameObject gameControllerObject = GameObject.FindWithTag("GameController");
        if (gameControllerObject != null)
        {
            gameController = gameControllerObject.GetComponent<GameController>();
        }
        rBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        myTime += Time.deltaTime;
        if (timer >= 0.0)
        {
            fireRate = 0.10f;
            if (Input.GetButton("Fire2") && myTime > fireRate)
            {
                lasr.Play();
                Instantiate(laser2, LaserSpawn2Right.transform.position, LaserSpawn2Right.transform.rotation);
                myTime = 0.0f;
            }
        }
        else
        {
            if (Input.GetButton("Fire2") && myTime > fireRate)
            {
                lasr.Play();
                Instantiate(laser2, LaserSpawn2Right.transform.position, LaserSpawn2Right.transform.rotation);
                myTime = 0.0f;
            }
        }
        fireRate = 0.15f;
    }
    //Fixed update increments. Used for physics
    void FixedUpdate()
    {
        if (canMove == true)
        {
            horiz = Input.GetAxis("Horizontal2");
            vert = Input.GetAxis("Vertical2");
        }

        movement = new Vector2(horiz, vert);

        rBody.velocity = movement * speed;

    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Ice")
        {
            canMove = false;
        }
        if (other.gameObject.tag == "Health")
        {
            gameController.player2HP += 1.0f;
            gameController.CheckPowerUpSpawn1 = true;
            Destroy(other.gameObject);
        }
        if (other.gameObject.tag == "FireRate")
        {
            timer = 5.0f;
            gameController.CheckPowerUpSpawn2 = true;
            Destroy(other.gameObject);
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Ice")
        {
            canMove = true;
        }
    }
}