// using System.Security.Cryptography;
// using Unity.VisualScripting;
// using UnityEngine;
// using UnityEngine.UI;

// // handles call to ui interaction
// public class DialogueActivator : MonoBehaviour, IInteractable 
// {
//     [SerializeField] private DialogueObject dialogueObject;

//     public void UpdateDialogueObject (DialogueObject dialogueObject) {
//         this.dialogueObject = dialogueObject;
//     }

//     public void OnTriggerEnter2D (Collider2D collider){
//         // does it have player tag and player component
//         if (collider.CompareTag("Player") && collider.TryGetComponent(out PlayerMovement player)) {
//             player.Interactable = this;
//         }
//     }

//     public void OnTriggerExit2D (Collider2D collider){
//         if (collider.CompareTag("Player") && collider.TryGetComponent(out PlayerMovement player)) {
//             if (player.Interactable is DialogueActivator dialogueActivator && dialogueActivator == this) {
//                 player.Interactable = null;
//             }
//         }
//     }

//     public void Interact (PlayerMovement player) {
//         foreach (DialogueResponseEvents responseEvents in GetComponents<DialogueResponseEvents>()) {
//             if (responseEvents.DialogueObject == dialogueObject) {
//                 player.DialogueUI.AddResponseEvents(responseEvents.Events);
//                 break;
//             }
//         }

//         player.DialogueUI.ShowDialogue(dialogueObject);
//     }
// }
