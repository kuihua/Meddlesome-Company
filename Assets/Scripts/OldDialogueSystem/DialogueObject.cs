// using Microsoft.Unity.VisualStudio.Editor;
// using UnityEngine;
// using UnityEngine.UI;

// [CreateAssetMenu(menuName = "Dialogue/DialogueObject")]
// public class DialogueObject : ScriptableObject
// {
//     [SerializeField] [TextArea] private string[] dialogue;
//     [SerializeField] private Response[] responses;
//     [SerializeField] private Sprite[] portraits;

//     // getter, prevents code from outside from writing to it, only read from it
//     public string[] Dialogue => dialogue;
//     public bool HasResponses => Responses != null && Responses.Length > 0;
//     public Response[] Responses => responses;
//     public Sprite[] Portraits => portraits;

// }
