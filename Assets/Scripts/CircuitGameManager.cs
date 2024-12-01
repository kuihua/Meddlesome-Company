using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class CircuitGameManager : MonoBehaviour
{
    // public GameObject circuitHolder;
    // public Graphic[] circuits;

    public int totalCircuits;
    public int correctCircuits = 0;
    public GameObject continueButton;
    // public Animator alarmAnim;

    // Start is called before the first frame update
    void Start()
    {
        // returns about of children it has
        // totalCircuits = circuitHolder.transform.childCount; 

        // foreach (Graphic c in circuits)
        // {
        //     if(c.GetComponent<CircuitScript>().GetIsPuzzlePiece()){
        //         totalCircuits++;
        //     }
        // }

        // for (int i = 0; i < circuits.Length; i++)
        // {
        //     if(circuits[i].GetComponent<CircuitScript>().GetIsPuzzlePiece()){
        //         totalCircuits++;
        //     }
        // }
        continueButton.SetActive(false);
        // StartCoroutine(LateStart(3));

        // circuits = new Graphic[totalCircuits];

        // for (int i = 0; i < circuits.Length; i++)
        // {
        //     circuits[i] = circuitHolder.transform.GetChild(i).GetComponent<Graphic>();
        // }
        
    }

    // if theres a cutscene at the beginning of scene, not all circuits will be counted
    // public void countCircuits(){
    //     totalCircuits = 0;
    //     for (int i = 0; i < circuits.Length; i++)
    //     {
    //         if(circuits[i].GetComponent<CircuitScript>().GetIsPuzzlePiece()){
    //             totalCircuits++;
    //         }
    //     }
    // }

    // IEnumerator LateStart(float waitTime)
    // {
    //     yield return new WaitForSeconds(waitTime);
    //     //Your Function You Want to Call
    //     for (int i = 0; i < circuits.Length; i++)
    //     {
    //         if(circuits[i].GetComponent<CircuitScript>().GetIsPuzzlePiece()){
    //             totalCircuits++;
    //         }
    //     }
    // }

    public void correctMove() {
        correctCircuits += 1;
        // Debug.Log("correct place");

        if (correctCircuits == totalCircuits) {
            continueButton.SetActive(true);
            // Debug.Log("you win");
            // alarmAnim.Play(0);
        }
    }

    public void wrongMove() {
        correctCircuits -= 1;
    }
}
