using UnityEngine;
using UnityEngine.Playables;

public class ActivateCutscene : MonoBehaviour
{
    [SerializeField] private PlayableDirector playableDirector; // timeline to play

    [Header("Activate Cutscene With E. Disables after.")]
    public bool isPressKeyToActivate;
    private bool playerDetected;
    public GameObject Player;
    public bool hasPlayed; // for testing
    [Header("Is it after a puzzle")]
    public bool afterPuzzle; 

    private SpriteRenderer sr;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E) && playerDetected && Player != null) {
            ActivateCutsceneKey();
        }
    }

    // activate the cutscene if the player enters the trigger area
    // disables the trigger afterwards so it won't happen again
    private void OnTriggerEnter2D (Collider2D collision) {
        if (collision.CompareTag("Player") && !isPressKeyToActivate && !afterPuzzle){
            playableDirector.Play();
            GetComponent<BoxCollider2D>().enabled = false;
        } else if (collision.CompareTag("Player")) {
            playerDetected = true;
            Player = collision.gameObject;
            if(sr != null) {
                sr.enabled = true;
            }
        }
    }

    void OnTriggerExit2D(Collider2D collision) {
        if(collision.CompareTag("Player")) {
            playerDetected = false;
            Player = null;
            if(sr != null) {
                sr.enabled = false;
            }
        }
    }

    public void ActivateCutsceneKey () {
        // function to play cutscene, disables this script when its done
        playableDirector.Play();
        GetComponent<ActivateCutscene>().enabled = false;
        // disables sprite; for triggers from talking to npcs because the speech icon will show
        if (GetComponent<SpriteRenderer>() != null){
            GetComponent<SpriteRenderer>().enabled = false;
            GetComponent<BoxCollider2D>().enabled = false;
        }
    }

}
