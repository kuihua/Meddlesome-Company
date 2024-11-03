using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class SelectChapter : MonoBehaviour, IPointerClickHandler
{
    public string sceneName;

    // // Start is called before the first frame update
    // void Start()
    // {
        
    // }

    // // Update is called once per frame
    // void Update()
    // {
        
    // }

    public void OnPointerClick(PointerEventData eventData) {
        // SceneManager.LoadSceneAsync("Intro");
        SceneManager.LoadScene(sceneName);
    }
}
