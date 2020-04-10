using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static AudioClip basketSound, fanSound;
    static AudioSource audioSrc;
    // Start is called before the first frame update
    void Start()
    {
        basketSound = Resources.Load<AudioClip>("basketSound");
        basketSound = Resources.Load<AudioClip>("fanSound");
        audioSrc = GetComponent<AudioSource>();
    }

    public static void PlaySound(string clip)
    {
        switch (clip)
        {
            case "basket":
                audioSrc.PlayOneShot(basketSound);
                break;
            case "fan":
                audioSrc.PlayOneShot(fanSound);
                break;
        }
    }
}
