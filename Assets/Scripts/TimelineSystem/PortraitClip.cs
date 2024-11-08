using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.UI;

public class PortraitClip : PlayableAsset
{
    public Sprite portrait;
    public override Playable CreatePlayable(PlayableGraph graph, GameObject owner)
    {
        // creating a playable behaviour
        var playable = ScriptPlayable<SubtitleBehaviour>.Create(graph);

        // get the behaviour 
        SubtitleBehaviour subtitleBehaviour = playable.GetBehaviour();

        // set the subtitle behaviour portrait based on the sprite on the clip
        subtitleBehaviour.portrait = portrait;

        return playable;
    }
}
