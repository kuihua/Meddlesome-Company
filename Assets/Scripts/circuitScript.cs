using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CircuitScript : MonoBehaviour, IPointerClickHandler
{
    // possible rotations
    float[] rotations = {0, 90, 180, 270};
    public float[] correctRotation;
    public bool isCorrect = false;
    public float angle;
    int possibleRotations = 1;

    RectTransform rectT;
    public Graphic circuit;
    public CircuitGameManager gameManager;
    public bool isPuzzlePiece;

    private void Awake() {
        // gameManager = GameObject.Find("CircuitMinigameManager").GetComponent<CircuitGameManager>();
    }

    private void Start() {
        possibleRotations = correctRotation.Length;
        if(possibleRotations > 0) isPuzzlePiece = true;
        rectT = circuit.rectTransform;
        int rand = Random.Range(0, rotations.Length);
        // transform.eulerAngles = new Vector3(0, 0, rotations[rand]);
        rectT.localEulerAngles = new Vector3(0, 0, rotations[rand]);
        angle = Mathf.Floor(rectT.localEulerAngles.z);

        // only 2 bc the highest possible number of correct rotations a circuit can have is 2 (which is the straight one)
        if (possibleRotations > 1) {
            if (angle == correctRotation[0] || angle == correctRotation[1]) {
                isCorrect = true;
                gameManager.correctMove();
            }
        } else if (possibleRotations == 1) {
            if (angle == correctRotation[0]) {
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
        angle = Mathf.Floor(rectT.localEulerAngles.z);

        if (possibleRotations == 0) {
            return;
        }

        if (possibleRotations > 1) {
            if ((angle == correctRotation[0] || angle == correctRotation[1]) && isCorrect == false) {
                isCorrect = true;
                gameManager.correctMove();
            } else if (isCorrect == true) {
                isCorrect = false;
                gameManager.wrongMove();
            }
        } else {
            if (angle == correctRotation[0] && isCorrect == false) {
                isCorrect = true;
                gameManager.correctMove();
            } else if (isCorrect == true) {
                isCorrect = false;
                gameManager.wrongMove();
            }
        } 
    }

    public bool GetIsPuzzlePiece(){
        return isPuzzlePiece;
    }

}
