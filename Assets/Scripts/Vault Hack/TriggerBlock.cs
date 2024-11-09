using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerBlock : MonoBehaviour
{
    public GameObject BlockPrefab;
    public VaultWall wall;
    float yOffset = 20;
    // float totalTime = 0;
    float chanceOfBlock = 0.7f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(wall.getHits() >= 8) {
            chanceOfBlock = 0.95f;
        }
        else if(wall.getHits() >= 3) {
            chanceOfBlock = 0.8f;
        }
    }

    // void FixedUpdate() {
    //     totalTime += Time.fixedDeltaTime;
    // }

    void OnTriggerEnter2D(Collider2D collider) {
        // if(collider)
        // float num = Random.Range(0, 1.0f);
        // Debug.Log(num);
        Debug.Log(chanceOfBlock);
        if(Random.Range(0, 1.0f) < chanceOfBlock) {
        // if(num < 0.7) {
            float yPos = Random.Range(transform.position.y - yOffset, transform.position.y + yOffset);
            // GameObject block = Instantiate(BlockPrefab, new Vector2(collider.transform.position.x, transform.position.y), Quaternion.identity);
            GameObject block = Instantiate(BlockPrefab, new Vector2(collider.transform.position.x, yPos), Quaternion.identity);
            block.transform.SetParent(gameObject.transform.parent);
        }
    }
}
