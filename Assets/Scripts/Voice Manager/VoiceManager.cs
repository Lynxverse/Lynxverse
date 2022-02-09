using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[Serializable]
public class VoiceOver
{
    public AudioClip audioClip;
    public float timerBeforeNext;
    public UnityEvent eventAfterAudioFinish;
}

[RequireComponent(typeof(AudioSource))]
public class VoiceManager : MonoBehaviour
{
    [SerializeField] VoiceEntity voiceEntity;
    [SerializeField] bool playOnStart = true;
    [SerializeField] bool autoPlayNextClip;
    [SerializeField] float delayBeforePlay = 2f;

    [Header("Audio Clip Setting"), Space(5)]
    [SerializeField] AudioSource audioSource;
    [SerializeField, Space(5)] List<VoiceOver> femaleVoiceOvers;
    [SerializeField, Space(5)] List<VoiceOver> maleVoiceOvers;

    int currentIdx = 0;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        currentIdx = 0;
        if (playOnStart)
            StartCoroutine(DelayBeforeStart());
    }

    public void PlayVoiceOver()
    {
        if (voiceEntity.voiceChoosen == VoiceEntity.VOICE_CHOOSEN.MALE)
        {
            StartCoroutine(PlayMaleVoice());
        }
        else if (voiceEntity.voiceChoosen == VoiceEntity.VOICE_CHOOSEN.FEMALE)
        {
            StartCoroutine(PlayFemaleVoice());
        }
    }

    IEnumerator PlayMaleVoice()
    {
        if (autoPlayNextClip)
        {
            while (currentIdx < maleVoiceOvers.Count)
            {
                audioSource.clip = maleVoiceOvers[currentIdx].audioClip;
                audioSource.Play();
                while (audioSource.isPlaying)
                {
                    Debug.Log("Current Index: " + currentIdx + " | playing clip: " + maleVoiceOvers[currentIdx].audioClip.name);
                    yield return null;
                }
                maleVoiceOvers[currentIdx].eventAfterAudioFinish?.Invoke();
                yield return new WaitForSeconds(maleVoiceOvers[currentIdx].timerBeforeNext);
                currentIdx += 1;
            }
        }
        else
        {
            if (currentIdx < maleVoiceOvers.Count)
            {
                audioSource.clip = maleVoiceOvers[currentIdx].audioClip;
                audioSource.Play();
                while (audioSource.isPlaying)
                {
                    Debug.Log("Current Index: " + currentIdx + " | playing clip: " + maleVoiceOvers[currentIdx].audioClip.name);
                    yield return null;
                }
                maleVoiceOvers[currentIdx].eventAfterAudioFinish?.Invoke();
                yield return new WaitForSeconds(maleVoiceOvers[currentIdx].timerBeforeNext);
                currentIdx += 1;
            }
            else
            {
                Debug.LogError("There's no more Audio Clip on the list");
            }
        }
        
    }

    IEnumerator PlayFemaleVoice()
    {
        if (autoPlayNextClip)
        {
            while (currentIdx < femaleVoiceOvers.Count)
            {
                audioSource.clip = femaleVoiceOvers[currentIdx].audioClip;
                audioSource.Play();
                while (audioSource.isPlaying)
                {
                    Debug.Log("Current Index: " + currentIdx + " | playing clip: " + femaleVoiceOvers[currentIdx].audioClip.name);
                    yield return null;
                }
                femaleVoiceOvers[currentIdx].eventAfterAudioFinish?.Invoke();
                yield return new WaitForSeconds(femaleVoiceOvers[currentIdx].timerBeforeNext);
                currentIdx += 1;
            }
        }
        else
        {
            if (currentIdx < femaleVoiceOvers.Count)
            {
                audioSource.clip = femaleVoiceOvers[currentIdx].audioClip;
                audioSource.Play();
                while (audioSource.isPlaying)
                {
                    Debug.Log("Current Index: " + currentIdx + " | playing clip: " + femaleVoiceOvers[currentIdx].audioClip.name);
                    yield return null;
                }
                femaleVoiceOvers[currentIdx].eventAfterAudioFinish?.Invoke();
                yield return new WaitForSeconds(femaleVoiceOvers[currentIdx].timerBeforeNext);
                currentIdx += 1;
            }
            else
            {
                Debug.LogError("There's no more Audio Clip on the list");
            }
        }
    }

    IEnumerator DelayBeforeStart()
    {
        yield return new WaitForSeconds(delayBeforePlay);
        PlayVoiceOver();
    }
}
