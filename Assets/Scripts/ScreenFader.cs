using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenFader : MonoBehaviour
{
    private Animator animator;
    private bool isFading = false;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public IEnumerator FadeToClear() {
        isFading = true;
        animator.SetTrigger("FadeToClear");
        while(isFading) {
            yield return null;
        }
    }

    public IEnumerator FadeToBlack() {
        isFading = true;
        animator.SetTrigger("FadeToBlack");
        while(isFading) {
            yield return null;
        }
    }

    void AnimationComplete() {
        isFading = false;
    }
}
