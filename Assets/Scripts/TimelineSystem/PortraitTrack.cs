using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;
using UnityEngine.UI;


[TrackBindingType(typeof(Image))]
[TrackClipType(typeof(PortraitClip))]
public class PortraitTrack : TrackAsset
{
    public override Playable CreateTrackMixer(PlayableGraph graph, GameObject go, int inputCount)
    {
        return ScriptPlayable<SubtitleTrackMixer>.Create(graph, inputCount);
    }
}
