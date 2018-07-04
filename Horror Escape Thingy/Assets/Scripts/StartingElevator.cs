using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartingElevator : MonoBehaviour {
    int distance = 10;
    int speed = 5;
    float decent = 0.01f;
    
    Vector3 myPosition;

    // Use this for initialization
    void Start () {
        myPosition = new Vector3(10.39693f, 15.73292f, -2.612766f);
    }
	
	// Update is called once per frame
	void Update () {

        for (int i = 0; i < distance; i++)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y - decent, transform.position.z);
        }
    }
}
