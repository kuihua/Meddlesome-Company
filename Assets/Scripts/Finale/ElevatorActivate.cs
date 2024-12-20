using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorActivate : MonoBehaviour
{
    ElevatorButton leftButton, rightButton;
    bool bothDetected = false;

    public GameObject onElevator;

    // Start is called before the first frame update
    void Start()
    {
        leftButton = transform.GetChild(0).GetComponent<ElevatorButton>();
        rightButton = transform.GetChild(1).GetComponent<ElevatorButton>();
    }

    // Update is called once per frame
    void Update()
    {
        if(leftButton.detectsPlayer() && rightButton.detectsPlayer() && !bothDetected) {
            bothDetected = true;
            // Debug.Log("both detected");
            onElevator.SetActive(true);
        }
        else if(bothDetected && (leftButton.enabled || rightButton.enabled)) {
            leftButton.enabled = false;
            rightButton.enabled = false;
        }
    }
}
