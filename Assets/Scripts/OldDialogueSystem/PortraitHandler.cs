using UnityEngine;
using TMPro;
using UnityEngine.UI;
using Unity.VisualScripting;
using System.Collections.Generic;

public class PortraitHandler : MonoBehaviour
{
    [SerializeField] private Sprite portrait;

    private DialogueUI dialogueUI;
    private ResponseEvent[] responseEvents;
    List<GameObject> tempResponsesButtons = new List<GameObject>();

    public void Start() {
        dialogueUI = GetComponent<DialogueUI>();
    }

    public void UpdatePortrait (Sprite portrait) {
        this.portrait = portrait;
    }
    
}
