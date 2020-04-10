using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static AudioClip basketSound, fanSound, doorSound, elecSound, flushSound, gameOverSound, glassSound,
        goodGuessSound, lightSound, pcSound;
    static AudioSource audioSrc;
    // Start is called before the first frame update
    void Start()
    {
        basketSound = Resources.Load<AudioClip>("basketSound");
        fanSound = Resources.Load<AudioClip>("fanSound");
        doorSound = Resources.Load<AudioClip>("doorSound");
        elecSound = Resources.Load<AudioClip>("elecSound");
        flushSound = Resources.Load<AudioClip>("flushSound");
        gameOverSound = Resources.Load<AudioClip>("gameOverSound");
        glassSound = Resources.Load<AudioClip>("glassSound");
        goodGuessSound = Resources.Load<AudioClip>("goodGuessSound");
        lightSound = Resources.Load<AudioClip>("lightSound");
        pcSound = Resources.Load<AudioClip>("pcSound");
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
            case "door":
                audioSrc.PlayOneShot(doorSound);
                break;
            case "elec":
                audioSrc.PlayOneShot(elecSound);
                break;
            case "flush":
                audioSrc.PlayOneShot(flushSound);
                break;
            case "gameOver":
                audioSrc.PlayOneShot(gameOverSound);
                break;
            case "glass":
                audioSrc.PlayOneShot(glassSound);
                break;
            case "GG":
                audioSrc.PlayOneShot(goodGuessSound);
                break;
            case "light":
                audioSrc.PlayOneShot(lightSound);
                break;
            case "pc":
                audioSrc.PlayOneShot(pcSound);
                break;
        }
    }
}
