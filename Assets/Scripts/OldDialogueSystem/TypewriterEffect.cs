// using System;
// using System.Collections;
// using System.Collections.Generic;
// using TMPro;
// using Unity.Collections.LowLevel.Unsafe;
// using UnityEngine;

// public class TypewriterEffect : MonoBehaviour
// {
//     [SerializeField] private float typewriterSpeed = 50f;

//     public bool IsRunning {get; private set;}

//     private readonly List<Punctuation> punctuations = new List<Punctuation> {
//             new Punctuation(new HashSet<char>(){'.', '!', '?'}, 0.6f),
//             new Punctuation(new HashSet<char>(){',', ';', ':'}, 0.3f)
//     };

//     private Coroutine typingCoroutine;
//     private TMP_Text textLabel;
//     private string textToType;

//     // to run couroutine (what we what to type, what it types on)
//     public void Run(string textToType, TMP_Text textLabel) {
//         this.textToType = textToType;
//         this.textLabel = textLabel;

//         typingCoroutine = StartCoroutine(TypeText());
//     }

//     public void Stop() {
//         if (!IsRunning) return;

//         StopCoroutine(typingCoroutine); 
//         OnTypingCompleted();
//     }

//     // for typewriter effect
//     private IEnumerator TypeText() {
//         IsRunning = true;
//         // textLabel.text = string.Empty;
//         textLabel.maxVisibleCharacters = 0;
//         textLabel.text = textToType;
//         // elapsed time spent on writing
//         float t = 0;
//         // floor value of t which measures how many chars we want to text on screen at the given frame
//         int charIndex = 0;
 
//         while (charIndex < textToType.Length) {

//             int lastCharIndex = charIndex;

//             t += Time.deltaTime * typewriterSpeed;
//             charIndex = Mathf.FloorToInt(t);
//             charIndex = Mathf.Clamp(charIndex, 0, textToType.Length);

//             for (int i = lastCharIndex; i < charIndex; i++) {
//                 //  we don't want to wait at the last char
//                 bool isLast = i >= textToType.Length - 1;
//                 // textLabel.text = textToType.Substring(0, i + 1);
//                 textLabel.maxVisibleCharacters = i + 1;

//                 // check if it's punctuation, not the last char, and the next char is not a punctuation (so we can do ... w/o the waittime)
//                 if (IsPunctuation(textToType[i], out float waittime) && !isLast && !IsPunctuation(textToType[i + 1], out _)) {
//                     yield return new WaitForSeconds(waittime);
//                 }
//             }

//             yield return null;
//         }

//         OnTypingCompleted();

//     }

//     private void OnTypingCompleted()
//     {
//         IsRunning = false;
//         textLabel.maxVisibleCharacters = textToType.Length;
//     }

//     // out means this function will return a float
//     private bool IsPunctuation (char character, out float waitime) {
//         // check if the character belongs to a character in the dictionary and access their waittime
//         foreach (Punctuation punctuationCategory in punctuations) {
//             // we are accessing the 2 fields in the punctuation structure
//             if (punctuationCategory.Punctuations.Contains(character)) {
//                 waitime = punctuationCategory.WaitTime;
//                 return true;
//             }
//         }

//         waitime = default;
//         return false;
//     }

//     private readonly struct Punctuation {
//         public readonly HashSet<char> Punctuations;
//         public readonly float WaitTime;

//         public Punctuation (HashSet<char> punctuations, float waitTime) {
//             Punctuations = punctuations;
//             WaitTime = waitTime;
//         }
//     }
// }
