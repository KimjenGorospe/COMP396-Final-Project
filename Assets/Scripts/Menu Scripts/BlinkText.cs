using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class BlinkText : MonoBehaviour
{
    Text cont;
    
        void Start()
    {
        cont = GetComponent<Text>();
        StartCoroutine(Flash());
    }

    // Update is called once per frame
    public IEnumerator Flash()
    {
        while (true)
        {
            cont.text = "";
            yield return new WaitForSeconds(.5f);
            cont.text = "Press r to continue";
            yield return new WaitForSeconds(.5f);
        }
    }
}