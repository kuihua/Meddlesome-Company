using UnityEngine;
using UnityEngine.Playables;

public class ActivateCutscene : MonoBehaviour
{
    [SerializeField] private PlayableDirector playableDirector;

    // activate the cutscene if the player enters the trigger area
    // disables the trigger afterwards so it won't happen again
    private void OnTriggerEnter2D (Collider2D collision) {
        if (collision.CompareTag("Player")){
            playableDirector.Play();
            GetComponent<BoxCollider2D>().enabled = false;
        }
    }
}
