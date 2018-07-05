using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorDoorClose : MonoBehaviour
{
    int speed = 10; //The larger the number, the slower it moves
    float distance = 3; //Adjust the multiplier to change how many units to move
    public bool floorPressed = false; //this is the elevator buttons
    public GameObject eli;
    bool doorOpen = false;
    public bool buttonPressed = false;
    public GameObject doorEli;

    double timer = 0;
    
    void Start ()
    {
        //door.SetActive(true);   //I turned this off because we are making it move, rather than dissapear
    }
	
	void Update ()
    {
        timer = timer + Time.deltaTime;

        if (doorOpen == false && buttonPressed == true)
        {
            buttonPressed = false; //Prevents MoveDoor from being called more than once
            StartCoroutine(OpenDoor()); //This is needed in order to call an IEnumerator
        }
        else if (doorOpen == true && buttonPressed == true)
        {
            buttonPressed = false;
            StartCoroutine(CloseDoor(speed: 60)); //this keeps distance, the first option, default
        }

        if (floorPressed == true)
        {
            floorPressed = false;
            StartCoroutine(MoveElevator(10)); //Every floor is about a multiple of 5
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
    int eliSpeed = 10;

    IEnumerator MoveElevator(int distance = -5, int speed = 100)
    {
        for (int i = 0; i < speed; i++)
        {
            eli.transform.Translate(Vector3.up * distance / speed);
            yield return new WaitForSeconds(0.015f);
        }
    }
}
