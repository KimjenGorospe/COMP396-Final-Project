using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //-10 5, 4,-4
    //Variable Declaration
    [Header("Movement Settings")]
    public float speed = 3.5f;
    private Vector2 movement;
    private Vector2 fixedMovement;
    private float horiz;
    private float vert;
    private bool canMove = true;
//public float xMin, xMax, yMin, yMax;

[Header("Attack Settings")]
    public GameObject laser;
    public GameObject LaserSpawnLeft;
    public GameObject LaserSpawnRight;
    public float fireRate = 0.5f;
    private Rigidbody2D rBody;

    private float timer = 0.0f;
    private float myTime = 0.0f;
    public GameController gameController;

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
        if (timer >= 0.0f)
        {
            fireRate = 0.30f;
            if (Input.GetButton("Fire1") && myTime > fireRate)
            {
                lasr.Play();
                Instantiate(laser, LaserSpawnLeft.transform.position, LaserSpawnLeft.transform.rotation);
                Instantiate(laser, LaserSpawnRight.transform.position, LaserSpawnRight.transform.rotation);
                myTime = 0.0f;
            }
        }
        else
        {
            if (Input.GetButton("Fire1") && myTime > fireRate)
            {
                lasr.Play();
                Instantiate(laser, LaserSpawnLeft.transform.position, LaserSpawnLeft.transform.rotation);
                Instantiate(laser, LaserSpawnRight.transform.position, LaserSpawnRight.transform.rotation);
                myTime = 0.0f;
            }
        }
        fireRate = 0.5f;
    }
    //Fixed update increments. Used for physics
    void FixedUpdate()
    {
            if (canMove == true)
            {
                // Read input
                horiz = Input.GetAxis("Horizontal");
                vert = Input.GetAxis("Vertical");
            }
        //Debug.Log("x: " + horiz + ",y: " + vert);
        movement = new Vector2(horiz, vert);

        //Move the Player
        //Rigidbody2D rBody = GetComponent<Rigidbody2D>();
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
            gameController.player1HP += 1.0f;
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
