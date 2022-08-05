using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float movementSpeed = 10.0f;
    public float rotationSpeed = 100f;

    public GameObject Camera;
    public bool isAntForm = false;
    public int checkingside = 0;

    public int rightRotation;
    public int normalRotation;
    public int leftRotation;

    void Update()
    {
        if(gameObject.GetComponent<Stats>().isDead) {
            Destroy(gameObject.GetComponent<AIShootPlayer>());
            return;
        }

        //MOVEMENT
        if (Input.GetKey(KeyCode.W))
        {
            transform.position += transform.forward * Time.deltaTime * movementSpeed;
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.position += -transform.forward * Time.deltaTime * movementSpeed;
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.position += -transform.right * Time.deltaTime * movementSpeed;
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.position += transform.right * Time.deltaTime * movementSpeed;
        }
        
        //FORM CHANGE
        if(Input.GetKeyDown(KeyCode.C)) {
            if(isAntForm) {
                isAntForm = false;
                transform.localScale = new Vector3(1f,1f,1f);
            }

            else if(!isAntForm) {
            transform.localScale = new Vector3(0.33f,0.33f,0.33f);
            isAntForm = true;
            }
        }

        if(Input.GetKeyDown(KeyCode.Q)) {
            checkingside -= 1;

            if(checkingside == -2) {
                checkingside = 0;
            }

            checkSide();
        } else if (Input.GetKeyDown(KeyCode.E)) {
           checkingside += 1;

            if(checkingside == 2) {
                checkingside = 0;
            } 

            checkSide();
        }
    }

    public void checkSide() {
        if(checkingside == 0) {
            transform.eulerAngles = new Vector3(0,transform.eulerAngles.y,normalRotation);
        }

        else if(checkingside == 1) {
            transform.eulerAngles = new Vector3(transform.eulerAngles.x,transform.eulerAngles.y,rightRotation);
        }

        else if(checkingside == -1) {
            transform.eulerAngles = new Vector3(transform.eulerAngles.x,transform.eulerAngles.y,leftRotation);
        }
    }
}
