using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    new Input01 playerinputs;
    new public static bool HasInteracted;

    public void Start()
    {
        HasInteracted = false;
    }
    public void OnInteract()
    {
        HasInteracted = true;
        Debug.Log("It worked; you interacted :)");
        //This will show up if the Interact button works :)
    }
}
