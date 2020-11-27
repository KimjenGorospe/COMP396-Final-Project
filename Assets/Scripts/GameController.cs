using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class GameController : MonoBehaviour
{
    [Header("Players")]
    public GameObject Player;
    public GameObject Player2;
    public GameObject playerClone;
    public GameObject player2Clone;

    [Header("Spawning")]
    public GameObject PlayerSpawn;
    public GameObject Player2Spawn;
    public GameObject BalancedMech;
    public GameObject FastMech;
    public GameObject FlameMech;
    public GameObject BalancedMech2;
    public GameObject FastMech2;
    public GameObject FlameMech2;

    [Header("Power Ups")]
    public GameObject HealthPack;
    public GameObject DamageUp;
    public GameObject HealthPackClone;
    public GameObject DamageUpClone;

    [Header("Power Ups Spawning")]
    public GameObject PowerUpSpawn;
    public GameObject PowerUpSpawn2;
    public GameObject PowerUpSpawn3;
    public GameObject PowerUpSpawn4;

    private string Player1Choice;
    private string Player2Choice;

    [Header("UI Text Settings")]
    public Text Player1Label;
    public Text Player2Label;
    public Text Player1HPLabel;
    public Text Player2HPLabel;
    public Text Player1WinLabel;
    public Text Player2WinLabel;
    public Text RestartLabel;

    [Header("UI Object Settings")]
    public GameObject Player1WinSplash;
    public GameObject Player2WinSplash;

    [Header("Player Lives")]
    public double player1Lives;
    public double player1HP;
    public double player2Lives;
    public double player2HP;
    private bool restart;

    private float timer = 15.0f;
    public bool CheckPowerUpSpawn1 = true;
    public bool CheckPowerUpSpawn2 = true;


    // Use this for initialization
    void Start()
    {
        CheckPowerUpSpawn1 = true;
        CheckPowerUpSpawn2 = true;
        player1HP = 10;
        player2HP = 10;
        player2Lives = 3;
        player1Lives = 3;
        restart = false;
        RestartLabel.enabled = false;
        Player1WinLabel.enabled = false;
        Player2WinLabel.enabled = false;
        Debug.Log(PlayerPrefs.GetString("Player"));
        Player1Choice = PlayerPrefs.GetString("Player");
        Player2Choice = PlayerPrefs.GetString("Player2");
        if (Player1Choice == "1")
        {
            Player = BalancedMech.gameObject;
        }
        if (Player1Choice == "2")
        {
            Player = FastMech.gameObject;
        }
        if (Player1Choice == "3")
        {
            Player = FlameMech.gameObject;
        }
        if (Player2Choice == "4")
        {
            Player2 = BalancedMech2.gameObject;
        }
        if (Player2Choice == "5")
        {
            Player2 = FastMech2.gameObject;
        }
        if (Player2Choice == "6")
        {
            Player2 = FlameMech2.gameObject;
        }
        SpawnPlayer();
    }

    void Update()
    {
        //if (Input.GetButtonDown("joystick button 6"))
        //{
        //   Application.Quit();
        //}
        timer -= Time.deltaTime;
        if (timer <= 0.0f)
        {
            SpawnPowerUp();
            timer = 15.0f;
        }
        if (player1HP <= 0)
        {
            player1Lives -= 1;
            player1HP = 10;
            RespawnPlayer();
        }
        else
        {
            Debug.Log("TEST");
            Player1HPLabel.text = "HP: " + player1HP.ToString();
        }
        if (player2HP <= 0)
        {
            player2Lives -= 1;
            player2HP = 10;
            Player2HPLabel.text = "HP: " + player2HP.ToString();
            //KillPlayer();
            RespawnPlayer();

        }
        else
        {
            Player2HPLabel.text = "HP: " + player2HP.ToString();
        }
        if (player1Lives < 1)
        {
            Player2WinLabel.enabled = true;
            restart = true;
            Player1Label.text = "Lives: " + player1Lives.ToString();
        }
        else
        {
            Player1Label.text = "Lives: " + player1Lives.ToString();
        }
        if (player2Lives < 1)
        {
            Player1WinLabel.enabled = true;
            restart = true;
            Player2Label.text = "Lives: " + player2Lives.ToString();
        }
        else
        {
            Player2Label.text = "Lives: " + player2Lives.ToString();
        }

        //Check if your restarting
        if (restart == true)
        {
            RestartLabel.enabled = true;
            if (Input.GetButton("Submit"))
            {
                switch(PlayerPrefs.GetString("Round"))
                {
                    case ("1"):
                        {
                            PlayerPrefs.SetString("Round" , "2");
                            SceneManager.LoadScene("Test_Arena2");
                            break;
                        }
                    case ("2"):
                        {
                            PlayerPrefs.SetString("Round", "3");
                            SceneManager.LoadScene("Test_Arena3");
                            break;
                        }
                    case ("3"):
                        {
                            PlayerPrefs.SetString("Round", "4");
                            SceneManager.LoadScene("End");
                            break;
                        }
                }
                //Reloads the scene
            }
        }
        if (Input.GetKeyDown("1"))
        {
            Player = BalancedMech.gameObject; 
        }
        if (Input.GetKeyDown("2"))
        {
            Player = FastMech.gameObject;
        }
        if (Input.GetKeyDown("3"))
        {
            Player = FlameMech.gameObject;
        }
        if (Input.GetKeyDown("4"))
        {
            Player2 = BalancedMech.gameObject;
        }
        if (Input.GetKeyDown("5"))
        {
            Player = BalancedMech2.gameObject;
        }
        if (Input.GetKeyDown("6"))
        {
            Player = FastMech2.gameObject;
        }
    }
    void KillPlayer()
    {
        Destroy(playerClone.gameObject);
        Destroy(player2Clone.gameObject);
    }
    void SpawnPlayer()
    {
        playerClone = Instantiate(Player, PlayerSpawn.transform.position, PlayerSpawn.transform.rotation);
        player2Clone = Instantiate(Player2, Player2Spawn.transform.position, Player2Spawn.transform.rotation);        
    }
    void RespawnPlayer()
    {
        playerClone.transform.position = PlayerSpawn.transform.position;
        player2Clone.transform.position = Player2Spawn.transform.position;
    }
    void SpawnPowerUp()
    {
        if (CheckPowerUpSpawn1 == true)
        {
            HealthPackClone = Instantiate(HealthPack, PowerUpSpawn2.transform.position, PowerUpSpawn2.transform.rotation);
            HealthPackClone = Instantiate(HealthPack, PowerUpSpawn4.transform.position, PowerUpSpawn4.transform.rotation);
            CheckPowerUpSpawn1 = false;
        }
        if (CheckPowerUpSpawn2 == true)
        {
            DamageUpClone = Instantiate(DamageUp, PowerUpSpawn.transform.position, PowerUpSpawn.transform.rotation);
            DamageUpClone = Instantiate(DamageUp, PowerUpSpawn3.transform.position, PowerUpSpawn3.transform.rotation);
            CheckPowerUpSpawn2 = false;
        }
    }
}
