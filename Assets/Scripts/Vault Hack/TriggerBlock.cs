using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerBlock : MonoBehaviour
{
    public GameObject BlockPrefab;

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
        // float num = Random.Range(0, 1.0f);
        // Debug.Log(num);
        if(Random.Range(0, 1.0f) < 0.8) {
        // if(num < 0.7) {
            GameObject block = Instantiate(BlockPrefab, new Vector2(collider.transform.position.x, transform.position.y), Quaternion.identity);
            block.transform.SetParent(gameObject.transform.parent);
        }
    }
}
