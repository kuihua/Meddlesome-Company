// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using UnityEngine.UI;
// using UnityEngine.EventSystems;

// public class AnswerClick : MonoBehaviour, IPointerClickHandler
// {
//     // public Button button;
//     public bool answerClicked;
//     [SerializeField] public NPCExamine npcExamine;
//     // Start is called before the first frame update
//     void Start()
//     {
//         // button = GetComponent<Button>();
//         answerClicked = false;
//     }

//     // Update is called once per frame
//     void Update()
//     {
        
//     }

//     public void OnPointerClick(PointerEventData eventData)
//     {
//         for (int i = 0; i < npcExamine.GetButtons().Length; i++)
//         {
//             if (npcExamine.GetButtons()[i] != this){
//                 npcExamine.GetButtons()[i].enabled = false;
//                 break;
//             }
//         }
//     }

// }
