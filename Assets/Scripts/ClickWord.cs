using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ClickWord : MonoBehaviour, IPointerClickHandler
{
    Image img;
    public bool clicked;

    // Start is called before the first frame update
    void Start()
    {
        img = GetComponent<Image>();
        clicked = false;
    }

    // // Update is called once per frame
    // void Update()
    // {
        
    // }

    public void OnPointerClick(PointerEventData eventData) {
        if(!clicked) {
            img.color = new Color(img.color.r, img.color.g, img.color.b, 1f);
            clicked = true;
        }
    }
}
