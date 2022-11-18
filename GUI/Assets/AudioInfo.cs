using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class AudioInfo
{
    [SerializeField] private AudioClip audioClip;
    [SerializeField] [Range(0, 1)]private float volume;
}