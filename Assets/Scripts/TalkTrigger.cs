using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class TalkTrigger : MonoBehaviour
{
    private bool inrange;
    private Input01 playerinput;
    private InputManager manager;

    [Header("Ink Jason File :)")]
        [SerializeField] private TextAsset inkJSON;
    private void Awake()
    {
        inrange = false;
    }

    private void Update()
    {
        if (inrange = true)
        {
            if (InputManager.HasInteracted == true)
            {
                Debug.Log(inkJSON.text);
                return;
            }
        }
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            inrange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            inrange = false;
        }
    }
}
