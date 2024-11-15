using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class StartScreen : MonoBehaviour, IPointerClickHandler
{
    ScreenFader Sf;
    bool enteringScene;

    // Start is called before the first frame update
    void Start()
    {
        Screen.SetResolution(1920, 1080, FullScreenMode.FullScreenWindow);
        Sf = GameObject.Find("Canvas/Screen Fader").GetComponent<ScreenFader>();
        enteringScene = true;
    }

    // Update is called once per frame
    void Update()
    {
        // Debug.Log(Sf.IsFading());
        if(!Sf.IsFading() && enteringScene) {
            Sf.gameObject.SetActive(false);
            enteringScene = false;
        }
    }

    public void OnPointerClick(PointerEventData eventData) {
        // SceneManager.LoadSceneAsync("Intro");
        // SceneManager.LoadScene("SelectChapter");
        StartCoroutine(LoadChapterSelect());
    }

    IEnumerator LoadChapterSelect() {
        Sf.gameObject.SetActive(true);
        yield return StartCoroutine(Sf.FadeToBlack());
        SceneManager.LoadScene("SelectChapter");
    }
}
