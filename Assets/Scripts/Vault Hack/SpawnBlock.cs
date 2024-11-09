using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SpawnBlock : MonoBehaviour, IPointerClickHandler
{
    public GameObject BlockPrefab;
    public VaultWall wall;

    // // Start is called before the first frame update
    // void Start()
    // {
        
    // }

    // // Update is called once per frame
    // void Update()
    // {
        
    // }

    public void OnPointerClick(PointerEventData eventData) {
        GameObject block = Instantiate(BlockPrefab, Input.mousePosition, Quaternion.identity);
        block.transform.SetParent(gameObject.transform.parent);
        block.GetComponent<Block>().wall = wall;
    }
}
