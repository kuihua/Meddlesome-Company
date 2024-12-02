using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckExamineCondition : MonoBehaviour
{

    // if finished examining
    public GameObject afterExamineNoInv;
    public GameObject afterExamineYesInv;

    public GameObject inventory;
    private bool hasChecked;

    // Start is called before the first frame update
    void Start()
    {
        // inventory = GameObject.Find("Canvas/Inventory");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D (Collider2D collider) {
        if (!hasChecked) {
            if (inventory.activeSelf) {
                afterExamineYesInv.SetActive(true);
                hasChecked = true;
            } else {
                afterExamineNoInv.SetActive(true);
            }
        }
    }

}
