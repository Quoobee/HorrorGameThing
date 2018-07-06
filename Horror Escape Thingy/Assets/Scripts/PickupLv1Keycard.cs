using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupLv1Keycard : MonoBehaviour {
    public GameObject lv1Keycard;
    public GameObject flashLight;
    public GameObject onHandLight;
    bool haveCard;


	// Use this for initialization
	void Start () {
        lv1Keycard.SetActive(true);
        flashLight.SetActive(true);
        onHandLight.SetActive(false);
        haveCard = false;
    }
	
	// Update is called once per frame
	void Update () {
		if (flashLight.activeSelf == false)
        {
            onHandLight.SetActive(true);
        }
        if (lv1Keycard.activeSelf == false)
        {
            haveCard = true;
        }
	}

    void OnTriggerStay(Collider other)
    {
        Debug.Log("Initial Collision");
        if (Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("E Has Been Pressed");
            if (other.gameObject.tag == "Item")
            {
                Debug.Log("Collided");
                other.gameObject.SetActive(false);
            }
        }
    }
}
