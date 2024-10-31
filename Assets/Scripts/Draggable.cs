using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Draggable : MonoBehaviour, IDragHandler, IEndDragHandler
{
    public GameObject correctSlot;
    private GameObject slot;

    public bool inCorrectSlot;

    // Start is called before the first frame update
    void Start()
    {
        inCorrectSlot = false;
    }

    // // Update is called once per frame
    // void Update()
    // {
        
    // }

    public void OnDrag(PointerEventData eventData) {
        // Debug.Log("click");
        transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData) {
        inCorrectSlot = false;
        if(slot != null) {
            transform.position = slot.transform.position;
            if(slot == correctSlot) {
                inCorrectSlot = true;
                Debug.Log("correct slot");
            }
        }
    }

    void OnTriggerEnter2D(Collider2D collider) {
        // Debug.Log("trigger");
        slot = collider.gameObject;
    }

    void OnTriggerExit2D(Collider2D collider) {
        // Debug.Log("no trigger");
        slot = null;
    }
}
