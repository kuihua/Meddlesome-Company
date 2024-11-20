using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseScene : MonoBehaviour
{
    public GameObject GuardPrefab;
    public Transform spawnPos;
    public int direction;
    float timer;
    public GameObject CaughtScreen;
    ScreenFader Sf;

    // Start is called before the first frame update
    void Start()
    {
        timer = 3;
        Physics2D.IgnoreLayerCollision(6, 6, true);
        Sf = GameObject.Find("Canvas/Screen Fader").GetComponent<ScreenFader>();
    }

    // // Update is called once per frame
    // void Update()
    // {
        
    // }

    public IEnumerator Caught() {
        // Player.GetComponent<PlayerMovement>().Stop();
        // Player.GetComponent<PlayerMovement>().enabled = false;
        yield return StartCoroutine(Sf.FadeToBlack());
        CaughtScreen.SetActive(true);
    }

    void FixedUpdate() {
        if(timer > 0) {
            timer -= Time.fixedDeltaTime;
            if(timer <= 0) {
                // spawn guard
                Rigidbody2D rb = (Instantiate(GuardPrefab, spawnPos.position, Quaternion.identity)).GetComponent<Rigidbody2D>();
                rb.velocity = new Vector2(8 * direction, 0);
            }
        }
    }
}
