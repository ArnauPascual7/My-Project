using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;

public enum AudioClips
{
    Hit
}

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;
    public List<AudioClip> Clips = new List<AudioClip>();
    public Dictionary<AudioClips, AudioClip> ClipList = new Dictionary<AudioClips, AudioClip>();

    private void Awake()
    {
        Instance = this;
        ClipList.Add(AudioClips.Hit, Clips[0]);
    }
}
