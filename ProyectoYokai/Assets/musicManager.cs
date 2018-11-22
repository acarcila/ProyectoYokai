using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class musicManager : MonoBehaviour {

    [Header("Tracks")]
    public musicManager MusicManager;
    public List<AudioClip> AudioClip;
    public int AudioClipIndex;
    public bool DontDestroyOnLoadActive;
    [Space(10)]

    [Header("Fade In & Out")]
    public bool keepFadingIn;
    public bool keepFadingOut;


    // Use this for initialization
    void Start()
    {
        float volumenFadeIn = AudioListener.volume;
        volumenFadeIn = 0.5f;
        PlayFadeIn(0.01f, volumenFadeIn);
        PlayMusic(AudioClip[AudioClipIndex]);
        if (DontDestroyOnLoadActive)
        {
            DontDestroyOnLoad(this.gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void PlayMusic(AudioClip audioClip)
    {
        MusicManager.GetComponent<AudioSource>().PlayOneShot(audioClip);
    }

    public void PlayFadeIn(float speed, float maxVolume)
    {
        StartCoroutine(FadeIn(speed, maxVolume));
    }

    public void PlayFadeOut(float speed)
    {
        StartCoroutine(FadeOut(speed));
    }

    public void ChangeMusic(int index)
    {
        MusicManager.GetComponent<AudioSource>().Stop();
        PlayMusic(AudioClip[index]);
        float volumenFadeIn = 0.5f;
        PlayFadeIn(0.01f, volumenFadeIn);
    }

    public IEnumerator FadeIn(float speed, float maxVolume)
    {
        keepFadingIn = true;
        keepFadingOut = false;

        MusicManager.GetComponent<AudioSource>().volume = 0;
        float audioVolume = MusicManager.GetComponent<AudioSource>().volume;

        while (MusicManager.GetComponent<AudioSource>().volume < maxVolume && keepFadingIn)
        {
            audioVolume += speed;
            MusicManager.GetComponent<AudioSource>().volume = audioVolume;
            yield return new WaitForSeconds(0.01f);
        }
    }

    public IEnumerator FadeOut(float speed)
    {
        keepFadingIn = false;
        keepFadingOut = true;

        float audioVolume = MusicManager.GetComponent<AudioSource>().volume;

        while (MusicManager.GetComponent<AudioSource>().volume >= speed && keepFadingOut)
        {
            audioVolume -= speed;
            MusicManager.GetComponent<AudioSource>().volume = audioVolume;
            yield return new WaitForSeconds(0.01f);
        }
    }
}
