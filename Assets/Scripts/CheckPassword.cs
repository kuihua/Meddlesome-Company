using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

public class CheckPassword : MonoBehaviour, IPointerClickHandler
{
    public TMP_InputField inputField;

    // // Start is called before the first frame update
    // void Start()
    // {
        
    // }

    // // Update is called once per frame
    // void Update()
    // {
        
    // }

    public void OnPointerClick(PointerEventData eventData) {
        // Player.GetComponent<PlayerMovement>().enabled = true;
        // popupWindow.SetActive(false);
        if(inputField.text == "Nicole") {
            Debug.Log("Logging in");
        }
        else {
            Debug.Log("Wrong password");
        }
    }
}
