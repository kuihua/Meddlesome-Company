using UnityEngine;
using UnityEngine.Playables;

public class ActivateCutscene : MonoBehaviour
{
    [SerializeField] private PlayableDirector playableDirector;

    [Header("Activate Cutscene With E. Disables collider after.")]
    public bool isPressKeyToActivate;
    private bool playerDetected;
    public GameObject Player;
    public bool hasPlayed; // for testing

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E) && playerDetected && Player != null) {
            ActivateCutsceneKey();
        }
    }

// activate the cutscene if the player enters the trigger area
    // disables the trigger afterwards so it won't happen again
    private void OnTriggerEnter2D (Collider2D collision) {
        if (collision.CompareTag("Player") && !isPressKeyToActivate){
            playableDirector.Play();
            GetComponent<BoxCollider2D>().enabled = false;
        } else {
            playerDetected = true;
        }
    }

    private void ActivateCutsceneKey () {
        // function to play cutscene, disables this script when its done
        playableDirector.Play();
        GetComponent<ActivateCutscene>().enabled = false;
    }

}
