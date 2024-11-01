using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class circuitScript : MonoBehaviour, IPointerClickHandler
{
    // possible rotations
    float[] rotations = {0, 90, 180, 270};
    public float[] correctRotation;
    private bool isCorrect = false;
    int possibleRotations = 1;

    RectTransform rectT;
    public Graphic circuit;
    CircuitGameManager gameManager;

    private void Awake() {
        gameManager = GameObject.Find("CircuitMinigameManager").GetComponent<CircuitGameManager>();
    }

    private void Start() {
        possibleRotations = correctRotation.Length;
        rectT = circuit.rectTransform;
        int rand = Random.Range(0, rotations.Length);
        // transform.eulerAngles = new Vector3(0, 0, rotations[rand]);
        rectT.localEulerAngles = new Vector3(0, 0, rotations[rand]);

        // only 2 bc the highest possible number of correct rotations a circuit can have is 2 (which is the straight one)
        if (possibleRotations > 1) {
            if (rectT.localEulerAngles.z == correctRotation[0] || rectT.localEulerAngles.z == correctRotation[1]) {
                isCorrect = true;
                gameManager.correctMove();
            }
        } else {
            if (rectT.localEulerAngles.z == correctRotation[0]) {
                isCorrect = true;
                gameManager.correctMove();
            }
        }

    }

    // rotate circuit by 90 degrees when clicked
    public void OnPointerClick(PointerEventData eventData) {
        // transform.Rotate(new Vector3(0, 0, 90));
        // Debug.Log("rotated");
        rectT.Rotate(new Vector3(0, 0, 90));
        if (possibleRotations > 1) {
            if ((rectT.localEulerAngles.z == correctRotation[0] || rectT.localEulerAngles.z == correctRotation[1]) && isCorrect == false) {
                isCorrect = true;
                gameManager.correctMove();
            } else if (isCorrect == true) {
                isCorrect = false;
                gameManager.wrongMove();
            }
        } else {
            if (rectT.localEulerAngles.z == correctRotation[0] && isCorrect == false) {
                isCorrect = true;
                gameManager.correctMove();
            } else if (isCorrect == true) {
                isCorrect = false;
                gameManager.wrongMove();
            }
        }
    }

}
