using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    //Set a speed for the rotation
    public Transform playerBody;
	
	public float xRotation = 0f;
    public float rotationSpeed = 100f;
    //Get the rotation of the player.


    /*Example:
    * The players rotation is at 0,0,0.
    * Input is 1,0,0.
    * The rotation in space would be 0,0,0 + 1,0,0 = 1,0,0.
    * This would be to the right of the player.
    */

    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * rotationSpeed * Time.deltaTime;
		float mouseY = Input.GetAxis("Mouse Y") * rotationSpeed * Time.deltaTime;
		
		xRotation -= mouseY;
		xRotation = Mathf.Clamp(xRotation, -90f, 90f);
		
		transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
		playerBody.Rotate(Vector3.up * mouseX);

    }
}
