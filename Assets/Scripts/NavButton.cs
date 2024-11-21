using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class NavButton : MonoBehaviour, IPointerClickHandler
{
    public GameObject otherScreen;
    public GameObject thisScreen;

    // Start is called before the first frame update
    void Start()
    {
        if(thisScreen == null) {
            thisScreen = transform.parent.parent.gameObject;
        }
    }

    // // Update is called once per frame
    // void Update()
    // {
        
    // }

    public void OnPointerClick(PointerEventData eventData) {
        otherScreen.SetActive(true);
        thisScreen.SetActive(false);
    }
}
