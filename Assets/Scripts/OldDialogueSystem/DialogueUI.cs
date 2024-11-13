// using UnityEngine;
// using TMPro;
// using System.Collections.Generic;
// using UnityEngine.UI;
// using System;
// using System.Collections;

// public class DialogueUI : MonoBehaviour
// {
//     [SerializeField] private GameObject dialogueBox;
//     [SerializeField] private TMP_Text textLabel;

//     private TypewriterEffect typewriterEffect;
//     private ResponseHandler responseHandler;
//     private PortraitHandler PortraitHandler;
//     public bool isOpen {get; private set;}

//     private void Start() {
//         typewriterEffect = GetComponent<TypewriterEffect>();
//         responseHandler = GetComponent<ResponseHandler>();

//         CloseDialogueBox();
//     }

//     public void ShowDialogue(DialogueObject dialogueObject) {
//         isOpen = true;
//         dialogueBox.SetActive(true);
//         StartCoroutine(StepThroughDialogue(dialogueObject));
//     }

//     public void AddResponseEvents (ResponseEvent[] responseEvents) {
//         responseHandler.AddResponseEvents(responseEvents);
//     }

//     private IEnumerator StepThroughDialogue(DialogueObject dialogueObject) {
//         for (int i = 0; i < dialogueObject.Dialogue.Length; i++) {
//             string dialogue = dialogueObject.Dialogue[i];
//             yield return RunTypingEffect(dialogue);
//             textLabel.text = dialogue;

//             if (i == dialogueObject.Dialogue.Length - 1 && dialogueObject.HasResponses) break;
//             yield return null; // wait 1 frame here because next line is also E
//             yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.E));
//         }

//         if (dialogueObject.HasResponses) {
//             responseHandler.ShowResponses(dialogueObject.Responses);
//         } else {
//             CloseDialogueBox();
//         }

//     }

//     private IEnumerator RunTypingEffect(string dialogue) {
//         typewriterEffect.Run(dialogue, textLabel);

//         while (typewriterEffect.IsRunning) {
//             yield return null; // wait 1 frame

//             if (Input.GetKeyDown(KeyCode.E)) {
//                 typewriterEffect.Stop();
//             }
//         }
//     }

//     public void CloseDialogueBox() {
//         isOpen = false;
//         dialogueBox.SetActive(false);
//         textLabel.text = string.Empty;
//     }

// }
