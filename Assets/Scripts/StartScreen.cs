using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class StartScreen : MonoBehaviour, IPointerClickHandler
{
    // Start is called before the first frame update
    void Start()
    {
        Screen.SetResolution(1920, 1080, FullScreenMode.FullScreenWindow);
    }

    // // Update is called once per frame
    // void Update()
    // {
        
    // }

    public void OnPointerClick(PointerEventData eventData) {
        // SceneManager.LoadSceneAsync("Intro");
        SceneManager.LoadScene("SelectChapter");
    }
}
