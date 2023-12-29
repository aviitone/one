using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAim : MonoBehaviour
{
    private Transform aimTransf;
    private Input01 playerInput;
    private GameObject bullet;

    //Mouse position code by Hugo Cardoso
    public static Vector3 GetMousePosition()
    {
        Vector3 vec = GetMousePositionWithZ(Input.mousePosition, Camera.main);
        vec.z = 0f; return vec;
    }
    public static Vector3 GetMousePositionWithZ()
    {
        return GetMousePositionWithZ(Input.mousePosition, Camera.main);
    }
    public static Vector3 GetMousePositionWithZ(Camera worldCamera)
    {
        return GetMousePositionWithZ(Input.mousePosition, worldCamera);
    }
    public static Vector3 GetMousePositionWithZ(Vector3 screenPosition, Camera worldCamera)
    {
        Vector3 worldPosition = worldCamera.ScreenToWorldPoint(screenPosition);
        return worldPosition;
    }
    //Hugo Cardoso code end :)

    private void Awake()
    {
        aimTransf = transform.Find("RotationPoint");
        bullet = GameObject.Find("Bullet");
    }

    private void Aim()
    {
        //Rotating the gun :O
        Vector3 mousePosition = GetMousePosition();

        Vector3 aimDirection = (mousePosition - transform.position).normalized;
        float angle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg;
        aimTransf.eulerAngles = new Vector3(0, 0, angle);
    }

    private void Shoot()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Debug.Log("bang! >:3");
        }
    }

    private void Update()
    {
        Aim();
        Shoot();
    }
}
