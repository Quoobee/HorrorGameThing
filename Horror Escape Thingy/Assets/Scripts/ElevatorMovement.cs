using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorMovement : MonoBehaviour
{
    bool floorPressed = false; //this is the elevator buttons
    public GameObject eli;
    bool doorOpen = false;
    bool doorPressed = false;
    public GameObject doorEli;
    bool doorMoved = false;

    double timer = 0;
    
    void Start ()
    {
        //door.SetActive(true);   //I turned this off because we are making it move, rather than dissapear
    }
	
	void Update ()
    {
        timer = timer + Time.deltaTime; //This tells you the exact amount of time that has passed

        if (doorOpen == false && doorPressed == true)
        {
            doorPressed = false; //Prevents MoveDoor from being called more than once
            StartCoroutine(OpenDoor()); //This is needed in order to call an IEnumerator
        }
        else if (doorOpen == true && doorPressed == true)
        {
            doorPressed = false;
            StartCoroutine(CloseDoor()); //this keeps distance, the first option, default
        }

        if (floorPressed == true && doorMoved == false)
        {
            floorPressed = false;
            doorMoved = true;
            StartCoroutine(MoveElevator(-10)); //Every floor is about a multiple of 5
        }
    }

    // \/ This is needed to call WaitForSeconds
    IEnumerator OpenDoor(float distance = 3, int speed = 10) //when equals is selected, defaults
    {
        for (int i = 0; i < speed; i++) 
        {
            doorEli.transform.Translate(Vector3.back * distance / speed); //.back is z-1 
            yield return new WaitForSeconds(0.015f); //This CAN NOT be in Update()
        }
        doorOpen = true; //Prevents MoveDoor from being called more than once
    }

    IEnumerator CloseDoor(float distance = 3, int speed = 10) //but chosen value replaces it
    {
        for (int i = 0; i < speed; i++)
        {
            doorEli.transform.Translate(Vector3.back * distance / speed * -1);
            yield return new WaitForSeconds(0.015f);
        }
        doorOpen = false;
    }

    IEnumerator MoveElevator(int distance = -5, int speed = 100)
    {
        for (int i = 0; i < speed; i++)
        {
            eli.transform.Translate(Vector3.up * distance / speed);
            yield return new WaitForSeconds(0.015f);
        }
    }

    void OnTriggerStay(Collider other)
    {
        Debug.Log("Initial Collision");
        if (Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("E Has Been Pressed");
            if (other.gameObject.tag == "door")
            {
                doorPressed = true;
            }
            else if (other.gameObject.tag == "floor")
            {
                floorPressed = true;
            }
        }
    }
}
