using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class SelectChapter : MonoBehaviour/*, IPointerClickHandler*/
{
    // public string sceneName;
    ScreenFader Sf;
    bool enteringScene;

    // Start is called before the first frame update
    void Start()
    {
        Sf = GameObject.Find("Canvas/Screen Fader").GetComponent<ScreenFader>();
        enteringScene = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(!Sf.IsFading() && enteringScene) {
            Sf.gameObject.SetActive(false);
            enteringScene = false;
        }
    }

    // public void OnPointerClick(PointerEventData eventData) {
    //     // SceneManager.LoadSceneAsync("Intro");
    //     // SceneManager.LoadScene(sceneName);
    //     StartCoroutine(LoadChapter());
    // }

    // IEnumerator LoadChapter() {
    //     Sf.gameObject.SetActive(true);
    //     yield return StartCoroutine(Sf.FadeToBlack());
    //     SceneManager.LoadScene(sceneName);
    // }

    IEnumerator LoadChapterScene(string sceneName) {
        Sf.gameObject.SetActive(true);
        yield return StartCoroutine(Sf.FadeToBlack());
        SceneManager.LoadScene(sceneName);
    }

    public void LoadChapter(string sceneName) {
        StartCoroutine(LoadChapterScene(sceneName));
    }
}
