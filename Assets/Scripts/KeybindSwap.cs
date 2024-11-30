using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeybindSwap : MonoBehaviour
{
    float timer = 5;
    bool pressed = false;
    
    // // Start is called before the first frame update
    // void Start()
    // {
        
    // }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Q)) {
            pressed = true;
        }
    }

    void FixedUpdate() {
        if(timer > 0 && pressed) {
            timer -= Time.fixedDeltaTime;
            if(timer <= 0) {
                gameObject.SetActive(false);
            }
        }
    }
}
