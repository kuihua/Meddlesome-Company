using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class FinishPuzzle : MonoBehaviour, IPointerClickHandler
{
    public GameObject popupWindow;
    public GameObject Player;
    public OpenPopup popupInteract;
    [Header("Has cutscene after?")]
    public ActivateCutscene activateCutscene;
    public bool hasCutsceneAfter;

    // Start is called before the first frame update
    void Start()
    {
        popupWindow = transform.parent.gameObject;
        Player = GameObject.Find("Player");
    }

    // // Update is called once per frame
    // void Update()
    // {
        
    // }

    public void OnPointerClick(PointerEventData eventData) {
        Player.GetComponent<PlayerMovement>().enabled = true;
        popupInteract.gameObject.SetActive(false);
        popupWindow.SetActive(false);
        if (hasCutsceneAfter) {
            activateCutscene.ActivateCutsceneKey();
        }
    } 
}
