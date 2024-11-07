using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class SubtitleClip : PlayableAsset
{
    public string subtitleText;
    public override Playable CreatePlayable(PlayableGraph graph, GameObject owner)
    {
        // creating a playable behaviour
        var playable = ScriptPlayable<SubtitleBehaviour>.Create(graph);

        // get the behaviour 
        SubtitleBehaviour subtitleBehaviour = playable.GetBehaviour();

        // set the subtitle behaviour text based on the subtitle text on the clip
        subtitleBehaviour.subtitleText = subtitleText;

        return playable;
    }
}
