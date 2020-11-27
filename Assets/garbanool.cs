using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class garbanool : MonoBehaviour
{
    public float velocity = 2.0f;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(transform.rotation.ToString());
    }
    // Update is called once per frame
    void Update()
    {
        float nextX = 0.0f;
        float nextY = 0.0f;
        float currentAngle = (transform.rotation.eulerAngles.z) * Mathf.Deg2Rad;

        if (Input.GetAxis("Horizontal") < 0)
        {
            //left
            transform.Rotate(0.0f, 0.0f, -2.5f);
            Debug.Log(transform.rotation.ToString());
        } 
        if (Input.GetAxis("Horizontal") > 0)
        {
            //right
            transform.Rotate(0.0f, 0.0f, -2.5f);
            Debug.Log(transform.rotation.ToString());
        }

        if (Input.GetAxis("Vertical") < 0)
        {
            nextX = velocity * Mathf.Cos(currentAngle);
            nextY = velocity * Mathf.Sin(currentAngle);
            transform.position += new Vector3(nextX, nextY, 0.0f);
        }
        if (Input.GetAxis("Vertical") > 0)
        {
            nextX = velocity * Mathf.Cos(currentAngle);
            nextY = velocity * Mathf.Sin(currentAngle);
            transform.position -= new Vector3(nextX, nextY, 0.0f);
        }
    }
}
