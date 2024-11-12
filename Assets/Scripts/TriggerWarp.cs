using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerWarp : MonoBehaviour
{
    public Transform target;
    
    private GameObject Player;
    private ScreenFader Sf;

    // Start is called before the first frame update
    void Start()
    {
        Sf = GameObject.Find("Canvas/Screen Fader").GetComponent<ScreenFader>();
        Player = GameObject.Find("Player");
    }

    // // Update is called once per frame
    // void Update()
    // {
        
    // }

    IEnumerator OnTriggerEnter2D(Collider2D collider) {
        if(collider.CompareTag("Player")) {
            Player.GetComponent<PlayerMovement>().Stop();
            Player.GetComponent<PlayerMovement>().enabled = false;
            yield return StartCoroutine(Sf.FadeToBlack());
            Player.transform.position = target.position;
            yield return new WaitForSeconds(0.5f);
            yield return StartCoroutine(Sf.FadeToClear());
            Player.GetComponent<PlayerMovement>().enabled = true;
        }
    }
}
