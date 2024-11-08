using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardChase : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collider) {
        if(collider.CompareTag("Player")) {
            if(collider.GetComponent<PlayerMovement>().enabled) {
                // collider.GetComponent<PlayerMovement>().Slow(0, 3);
                print("caught");
            }   
        }
    }
}
