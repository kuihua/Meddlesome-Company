using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ToggleButton : MonoBehaviour, IPointerClickHandler
{
    public GameObject toggleObject;

    // // Start is called before the first frame update
    // void Start()
    // {
        
    // }

    // // Update is called once per frame
    // void Update()
    // {
        
    // }

    public void OnPointerClick(PointerEventData eventData) {
        if(toggleObject.activeSelf) {
            toggleObject.SetActive(false);
        }
        else {
            toggleObject.SetActive(true);
        }
    }
}
