using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

// This script is used as a reference for everything else
// that needs to get an input :)
public class InputList : MonoBehaviour
{
    private bool menuY = false;
    private bool menuN = false;
    private bool Interact = false;

    private static InputList instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("Yo bro, You got one too many input thingys in the scene :O");
        }
        instance = this;
    }

    public static InputList GetInstance()
    {
        return instance;
    }

    public void InteractPressed(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            Interact = true;
        }
        else if (context.canceled)
        {
            Interact = false;
        }
    }

    public void AcceptPressed(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            menuY = true;
        }
        else if (context.canceled)
        {
            menuY =false;
        }
    }

    public void BackedOut(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            menuN = true;
        }
        else if (context.canceled)
        {
            menuN = false;
        }
    }
}
