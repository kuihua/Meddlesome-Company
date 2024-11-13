// using UnityEngine;
// using TMPro;
// using UnityEngine.UI;
// using Unity.VisualScripting;
// using System.Collections.Generic;

// public class ResponseHandler : MonoBehaviour
// {
//     [SerializeField] private RectTransform responseBox;
//     [SerializeField] private RectTransform responseButtonTemplate;
//     [SerializeField] private RectTransform responseContainer;

//     private DialogueUI dialogueUI;
//     private ResponseEvent[] responseEvents;
//     List<GameObject> tempResponsesButtons = new List<GameObject>();

//     public void Start() {
//         dialogueUI = GetComponent<DialogueUI>();
//     }

//     public void AddResponseEvents(ResponseEvent[] responseEvents) {
//         this.responseEvents = responseEvents;
//     }

//     public void ShowResponses (Response[] responses) {
//         float responseBoxHeight = 0;

//         for (int i = 0; i < responses.Length; i++) {
//             Response response = responses[i];
//             int responseIndex = i;

//             GameObject responseButton = Instantiate(responseButtonTemplate.gameObject, responseContainer);
//             responseButton.gameObject.SetActive(true);
//             responseButton.GetComponent<TMP_Text>().text = response.ResponseText;
//             responseButton.GetComponent<Button>().onClick.AddListener(() => OnPickedResponse(response, responseIndex));

//             tempResponsesButtons.Add(responseButton);

//             responseBoxHeight += responseButtonTemplate.sizeDelta.y;
//         } 

//         responseBox.sizeDelta = new Vector2(responseBox.sizeDelta.x, responseBoxHeight);
//         responseBox.gameObject.SetActive(true);
//     }

//     private void OnPickedResponse(Response response, int responseIndex) {
//         responseBox.gameObject.SetActive(false);

//         foreach (GameObject button in tempResponsesButtons) {
//             Destroy(button);
//         }
//         tempResponsesButtons.Clear();

//         // checks if have an index which is in bounds of the response events array
//         if (responseEvents != null && responseIndex <= responseEvents.Length) {
//             responseEvents[responseIndex].OnPickedResponse?.Invoke(); // checking if there's a response event at the response index then it will invoke its event
//         }

//         // clearing the array after a choice had been made
//         responseEvents = null;

//         if (response.DialogueObject) {
//             dialogueUI.ShowDialogue(response.DialogueObject);
//         } else {
//             dialogueUI.CloseDialogueBox();
//         }
//     }
// }
