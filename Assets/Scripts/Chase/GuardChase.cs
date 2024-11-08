using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardChase : MonoBehaviour
{
    Rigidbody2D rb;
    ChaseScene chase;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        chase = GameObject.Find("Chase Manager").GetComponent<ChaseScene>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator OnTriggerEnter2D(Collider2D collider) {
        if(collider.CompareTag("Player")) {
            PlayerMovement pm = collider.GetComponent<PlayerMovement>();
            if(pm.enabled) {
                pm.Stop();
                pm.enabled = false;
                rb.velocity = new Vector2(0, 0);
                print("caught");
                yield return StartCoroutine(chase.Caught());
            }   
        }
    }
}
