using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using TMPro;
using UnityEngine.UI;
using Unity.VisualScripting;

public class SubtitleTrackMixer : PlayableBehaviour
{
    public override void ProcessFrame(Playable playable, FrameData info, object playerData)
    {
        // for the dialogue text
        TextMeshProUGUI text = playerData as TextMeshProUGUI;
        string currentText = "";
        float currentAlpha = 0f;

        // for the dialogue portrait
        // Image t = playerData as Image;
        // Debug.Log(playerData as Image);
        // Sprite portrait = null;
        // Sprite currentPortrait = null;

        if (!text) {
            // Debug.Log(t);
            // Sprite portrait = t.GetComponent<Image>().sprite;

            return;
        }
        
        // get the number of clips on the track
        int inputCount = playable.GetInputCount();
        for (int i = 0; i < inputCount; i++)
        {
            // getting weight of clip so we know which one is active
            float inputWeight = playable.GetInputWeight(i);

            // setting it as the active text and weight
            if (inputWeight > 0) {
                ScriptPlayable<SubtitleBehaviour> inputPlayable = (ScriptPlayable<SubtitleBehaviour>)playable.GetInput(i);
                SubtitleBehaviour input = inputPlayable.GetBehaviour();

                // setting info
                currentText = input.subtitleText;
                currentAlpha = inputWeight;
                // currentPortrait = input.portrait;
            }

        }

        text.text = currentText;
        text.color = new Color (1, 1, 1, currentAlpha);
        // t.gameObject.GetComponent<Image>().sprite = currentPortrait;

    }
}
