using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundArea : MonoBehaviour
{
    public List<GuardStealth> inRange;

    // Start is called before the first frame update
    void Start()
    {
        inRange = new List<GuardStealth>();
    }

    // // Update is called once per frame
    // void Update()
    // {
        
    // }

    void OnTriggerEnter2D(Collider2D collider)
    {
        // Debug.Log("trigger");
        GuardStealth guard = collider.gameObject.GetComponent<GuardStealth>();
        if(guard != null && !inRange.Contains(guard)) {
            inRange.Add(guard);
            // Debug.Log("add");
        }
    }

    void OnTriggerExit2D(Collider2D collider)
    {
        GuardStealth guard = collider.gameObject.GetComponent<GuardStealth>();
        if(guard != null && inRange.Contains(guard)) {
            inRange.Remove(guard);
        }
    }
}
