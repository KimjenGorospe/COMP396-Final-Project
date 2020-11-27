using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2Rotation : MonoBehaviour
{
    [Header("Movement Settings 2")]
    public float speed = 5f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(0, 0, Input.GetAxis("RightTurn2")), 45 * Time.deltaTime * speed);
    }
}
