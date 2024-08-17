using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    private GameObject character;
    void Awake()
    {
        Cursor.lockState = CursorLockMode.Locked;
        character = GameObject.Find("Character");
    }

    // Update is called once per frame
    void Update()
    {
        
        transform.position = character.transform.position;
        transform.RotateAround(gameObject.transform.position, -transform.right, Input.GetAxis("Mouse Y"));
        transform.RotateAround(gameObject.transform.position, Vector3.up, Input.GetAxis("Mouse X"));

        if (Cursor.lockState == CursorLockMode.None && Input.GetMouseButtonDown(1))
        {
            Cursor.lockState = CursorLockMode.Locked;
        }
        else if (Cursor.lockState == CursorLockMode.Locked && Input.GetKeyDown(KeyCode.Escape))
        {
            Cursor.lockState = CursorLockMode.None;
        }
    }
}
