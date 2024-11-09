using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomProjectiles : MonoBehaviour
{
    public GameObject ProjectilePrefab;
    public Transform minX, maxX;
    float yVel = -800;
    float timer = 1;
    float totalTime = 0;
    // float projectileInterval;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate() {
        if(timer > 0) {
            timer -= Time.fixedDeltaTime;
            if(timer <= 0) {
                float xPos = Random.Range(minX.position.x, maxX.position.x);
                // Debug.Log(xPos);
                GameObject projectile = Instantiate(ProjectilePrefab, new Vector2(xPos, transform.position.y), Quaternion.identity);
                projectile.transform.SetParent(gameObject.transform.parent);
                projectile.GetComponent<Rigidbody2D>().velocity = new Vector2(0, yVel);
                if(totalTime < 10) {
                    timer = 1;
                }
                else if(totalTime < 20) {
                    timer = 0.5f;
                }
                else {
                    timer = 0.25f;
                }
            }
        }
        totalTime += Time.fixedDeltaTime;
    }
}
