using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static AudioClip basketSound, fanSound, doorSound, elecSound, waterSound, waterStopSound, flushSound, doorBellSound, fairyPlantSound, gameOverSound, glassSound,
        goodGuessSound, lightSound, pcSound;
    static AudioSource audioSrc;
    // Start is called before the first frame update
    void Start()
    {
        basketSound = Resources.Load<AudioClip>("basketSound");
        fanSound = Resources.Load<AudioClip>("fanSound");
        doorSound = Resources.Load<AudioClip>("doorSound");
        elecSound = Resources.Load<AudioClip>("elecSound");
        waterSound = Resources.Load<AudioClip>("water");
        waterStopSound = Resources.Load<AudioClip>("waterStop");
        flushSound = Resources.Load<AudioClip>("flushSound");
        doorBellSound = Resources.Load<AudioClip>("doorbell");
        fairyPlantSound = Resources.Load<AudioClip>("fairyPlant");
        gameOverSound = Resources.Load<AudioClip>("gameOverSound");
        glassSound = Resources.Load<AudioClip>("glassSound");
        goodGuessSound = Resources.Load<AudioClip>("goodGuessSound");
        lightSound = Resources.Load<AudioClip>("lightSound");
        pcSound = Resources.Load<AudioClip>("pcSound");
        audioSrc = GetComponent<AudioSource>();

    }

    public static void PlaySound(string clip)
    {
        audioSrc.volume = 1;
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
            case "water":
                audioSrc.PlayOneShot(waterSound);
                audioSrc.volume = 0.3f;
                break;
            case "waterStop":
                audioSrc.PlayOneShot(waterStopSound);
                audioSrc.volume = 0.5f;
                break;
            case "flush":
                audioSrc.PlayOneShot(flushSound);
                audioSrc.volume = 0.2f;
                break;
            case "doorBell":
                audioSrc.PlayOneShot(doorBellSound);
                break;
            case "fairySound":
                audioSrc.PlayOneShot(fairyPlantSound);
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
