using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerLook : MonoBehaviour
{
    GameObject torso;
    private Camera cam;
    bool isMouse;
    Vector2 currentCursorPos;

    // Start is called before the first frame update
    void Start()
    {
        torso = GameObject.Find("Torso");
        cam = GameObject.Find("Main Camera").GetComponent<Camera>();
        isMouse = false; //Assume gamepad until mouse input
        currentCursorPos = Vector2.up;
    }

    private void Update()
    {
        if (isMouse)
            RotateTorso(PosCursorOffset());
    }

    public void Look(InputAction.CallbackContext context)
    {
       //processes mouse and right stick movement
        currentCursorPos = context.ReadValue<Vector2>();
        Debug.Log(currentCursorPos);
        if (context.control.name.Equals("position"))    //if mouse movement
        {
            isMouse = true;
            RotateTorso(PosCursorOffset());
        }
        else
        {
            isMouse = false;
            if (currentCursorPos != Vector2.zero)  //we don't want vertical snapping
            {
                RotateTorso(currentCursorPos);
            }
        }
    }

    private Vector2 PosCursorOffset()
    {
       //Return a heading to the cursor from my position
        Vector3 playerPos = cam.WorldToScreenPoint(transform.position);
        return new Vector2(currentCursorPos.x - playerPos.x, currentCursorPos.y - playerPos.y);
    }

    private void RotateTorso(Vector2 heading)
    {
        //look at heading, from input
        heading.x *= -1;
        torso.transform.eulerAngles = new(0, Vector2.SignedAngle(Vector2.up, heading));
    }
}
