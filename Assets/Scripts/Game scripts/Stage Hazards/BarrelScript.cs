using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrelScript : MonoBehaviour
{
    public GameObject explosion;
    private float fuse = 1.0f;
    private float detonate = 0.0f;
    private bool lit = false;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (lit == true)
        {
            fuse -= Time.deltaTime;
            if (fuse <= detonate)
            {
                Instantiate(explosion, this.transform.position, this.transform.rotation);
                Destroy(this.gameObject);
            }
        }
    }

    void OnTriggerEnter2D (Collider2D other)
    {
        if (other.tag == "Bullet")
        {
            Destroy(other.gameObject);
            if (lit == false)
            {
                lit = true;
            }
        }
        if (other.tag == "Explosion")
        {
            if (lit == false)
            {
                lit = true;
            }
        }
    }

}
