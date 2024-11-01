using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class CircuitGameManager : MonoBehaviour
{
    public GameObject circuitHolder;
    public Graphic[] circuits;

    public int totalCircuits = 0;
    int correctCircuits = 0;

    // Start is called before the first frame update
    void Start()
    {
        // returns about of children it has
        totalCircuits = circuitHolder.transform.childCount;

        circuits = new Graphic[totalCircuits];

        for (int i = 0; i < circuits.Length; i++)
        {
            circuits[i] = circuitHolder.transform.GetChild(i).GetComponent<Graphic>();
        }
        
    }

    public void correctMove() {
        correctCircuits += 1;
        Debug.Log("correct place");

        if (correctCircuits == totalCircuits) {
            Debug.Log("you win");
        }
    }

    public void wrongMove() {
        correctCircuits -= 1;
    }
}
