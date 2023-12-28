using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TalkTrigger : MonoBehaviour
{
    private bool inrange;

    private void Awake()
    {
        inrange = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (Collider.gameObject.tag == "Player")
        {
            inrange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (Collider.gameObject.tag == "Player")
        {
            inrange = false;
        }
    }
}
