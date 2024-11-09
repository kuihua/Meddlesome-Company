using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SpawnProjectile : MonoBehaviour, IPointerClickHandler
{
    public GameObject ProjectilePrefab;
    float yVel = 800;

    // // Start is called before the first frame update
    // void Start()
    // {
        
    // }

    // // Update is called once per frame
    // void Update()
    // {
        
    // }

    public void OnPointerClick(PointerEventData eventData) {
        // Debug.Log("clicked");
        GameObject projectile = Instantiate(ProjectilePrefab, Input.mousePosition, Quaternion.identity);
        projectile.transform.SetParent(gameObject.transform.parent);
        projectile.GetComponent<Rigidbody2D>().velocity = new Vector2(0, yVel);
    }
}
