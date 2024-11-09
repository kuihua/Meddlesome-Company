using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    public VaultWall wall;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collider) {
        // if(collider)
        if(wall != null) {
            wall.addBlocked();
        }
        Destroy(collider.gameObject);
        Destroy(gameObject);
    }
}
