using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnColAnimation : MonoBehaviour
{
    public Animation PillarFall;

    void Awake()
    {
        PillarFall = GetComponent<Animation>();
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            PillarFall.CrossFade(PillarFall.name);
        }
    }
}
