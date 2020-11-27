using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OilController : MonoBehaviour
{
    public GameObject explosion;

    private void OnTriggerEnter2D(Collider2D arson)
    {
        if (arson.tag == "Player")
        {
            Instantiate(explosion, this.transform.position, this.transform.rotation);
            Destroy(this.gameObject);
        }
    }
}
