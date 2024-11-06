using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

public class CheckPassword : MonoBehaviour, IPointerClickHandler
{
    public TMP_InputField inputField;

    public GameObject loginScreen;
    public GameObject fileScreen;
    public GameObject closeButton;

    // Start is called before the first frame update
    void Start()
    {
        loginScreen = transform.parent.gameObject;
    }

    // // Update is called once per frame
    // void Update()
    // {
        
    // }

    public void OnPointerClick(PointerEventData eventData) {
        // Player.GetComponent<PlayerMovement>().enabled = true;
        // popupWindow.SetActive(false);
        if(inputField.text == "Nicole") {
            Debug.Log("Logging in");
            closeButton.GetComponent<ClosePopup>().enabled = false;
            closeButton.GetComponent<FinishPuzzle>().enabled = true;
            fileScreen.SetActive(true);
            loginScreen.SetActive(false);
        }
        else {
            Debug.Log("Wrong password");
        }
    }
}
