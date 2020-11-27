using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Play : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //SceneManager.LoadScene("Test_Arena");
    }
    public void load(string Character_Select)
    {
        SceneManager.LoadScene(Character_Select);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Start"))
        {
            SceneManager.LoadScene("Character_Select");
        }
        if (Input.GetButton("Submit"))
        {
            SceneManager.LoadScene("Character_Select");
        }
    }
}
