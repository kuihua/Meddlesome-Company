using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CutWire : MonoBehaviour, IPointerClickHandler
{
    WireCut wireCutBox;

    // Start is called before the first frame update
    void Start()
    {
        wireCutBox = transform.parent.GetComponent<WireCut>();
    }

    // // Update is called once per frame
    // void Update()
    // {
        
    // }

    public void OnPointerClick(PointerEventData eventData) {
        wireCutBox.cutWire(gameObject);
        gameObject.SetActive(false);
    }
}
