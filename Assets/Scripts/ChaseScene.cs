using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseScene : MonoBehaviour
{
    public GameObject GuardPrefab;
    public Transform spawnPos;
    float timer;

    // Start is called before the first frame update
    void Start()
    {
        timer = 3;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate() {
        if(timer > 0) {
            timer -= Time.fixedDeltaTime;
            if(timer <= 0) {
                // spawn guard
                Rigidbody2D rb = (Instantiate(GuardPrefab, spawnPos.position, Quaternion.identity)).GetComponent<Rigidbody2D>();
                rb.velocity = new Vector2(-7, 0);
            }
        }
    }
}
