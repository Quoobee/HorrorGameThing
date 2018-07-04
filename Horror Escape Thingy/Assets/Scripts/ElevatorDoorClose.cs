using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorDoorClose : MonoBehaviour
{
    public bool doorOpen = false;
    //int speed = 1;   //I removed speed, because it makes more sense, and saves space just dividing distance
    //int distance = 200; //I removed this to simplify the code for now
    public bool buttonPressed = false;
    public GameObject door;
    
    void Start ()
    {
        //door.SetActive(true);   //I turned this off because we are making it move, rather than dissapear
    }
	
	void Update ()
    {
        if (doorOpen == false && buttonPressed == true)
        {
            buttonPressed = false;
            Debug.Log("Condition is met, button is set to false");
            StartCoroutine(MoveDoor()); //This is needed in order to call an IEnumerator
        }
    }

    IEnumerator MoveDoor() //This is needed to call WaitForSeconds
    {
        Debug.Log("Called MoveDoor");
        for (int i = 0; i < 60; i++)
        {
            door.transform.Translate(Vector3.back );
            Debug.Log("Moved Door");
            yield return new WaitForSeconds(1); //this CAN NOT be in Update()
        }
        Debug.Log("Door is done moving, door Open is set to true");
        doorOpen = true;


    }
}
