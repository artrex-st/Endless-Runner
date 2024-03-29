using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PicUp : MonoBehaviour, IPicUps
{
    [SerializeField] private AudioClip picUpSound;
    [SerializeField] private GameObject visual;
    [Header("Components")]
    private AudioSource audioSource;
    private AudioSource AudioSource => audioSource == null ? audioSource = GetComponent<AudioSource>() : audioSource;
    public void OnPic()
    {
        AudioUtils.PlayAudioCue(AudioSource,picUpSound);
        visual.SetActive(false);
        Destroy(gameObject,picUpSound.length);
    } 
}
