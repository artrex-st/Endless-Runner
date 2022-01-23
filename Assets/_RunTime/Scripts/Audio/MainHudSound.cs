using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(AudioSource))]
public class MainHudSound : MonoBehaviour
{
    [SerializeField] private AudioClip btnPressSound;
    [SerializeField] private AudioClip countDownSound;
    [SerializeField] private AudioClip countDownEndSound;
    [Header("Components")]
    private AudioSource audioSource;
    private AudioSource AudioSource => audioSource == null ? audioSource = GetComponent<AudioSource>() : audioSource;

    public void PlayButtonPressSound()
    {
        Play(btnPressSound);
    }
    public void PlayCountDownSound()
    {
        Play(countDownSound);
    }
    public void PlayCountDownEndSound()
    {
        Play(countDownEndSound);
    }
    private void Play(AudioClip _Clip)
    {
        AudioUtils.PlayAudioCue(AudioSource,_Clip);
    }
}
