using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterSelect : MonoBehaviour
{
    private bool ready1 = false;
    private bool ready2 = false;
    // Start is called before the first frame update
    void Start()
    {
    ready1 = false;
    ready2 = false;
}
    // Update is called once per frame
    void Update()
    {
        if (ready1 == false)
        {
            if (Input.GetButtonDown("1"))
            {
                PlayerPrefs.SetString("Player", "1");
                ready1 = true;
            }
            if (Input.GetButtonDown("2"))
            {
                PlayerPrefs.SetString("Player", "2");
                ready1 = true;
            }
            if (Input.GetButtonDown("3"))
            {
                PlayerPrefs.SetString("Player", "3");
                ready1 = true;
            }
        }
        if (ready2 == false)
        {
            if (Input.GetButtonDown("4"))
            {
                PlayerPrefs.SetString("Player2", "4");
                ready2 = true;
            }
            if (Input.GetButtonDown("5"))
            {
                PlayerPrefs.SetString("Player2", "5");
                ready2 = true;
            }
            if (Input.GetButtonDown("6"))
            {
                PlayerPrefs.SetString("Player2", "6");
                ready2 = true;
            }
        }
        if (ready1 == true & ready2 == true)
        {
            PlayerPrefs.SetString("Round", "1");
            SceneManager.LoadScene("Test_Arena");
        }
        }
}
