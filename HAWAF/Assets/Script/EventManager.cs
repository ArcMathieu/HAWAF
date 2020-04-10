using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    int gameStage = 1;
    public LightManager lightManager;
    public CodeSpawn codeSpawn;
    public bool correctAnswer = false;
    public bool amIPlayer1;
    public MainMenu loadingManager;
    public int finalSceneID;
    public VideoManager videoManager;
    public UnityEngine.Video.VideoClip[] myVideos = new UnityEngine.Video.VideoClip[1];
    public Animator[] myAnimators = new Animator[1];
    public bool firstVideoOver = false;
    bool turnOffLight = true;
    int i = 0;
    bool playPCSound = false;
    bool playLightSound = false;
    bool playElecSound = false;
    bool playDoorSound = false;
    bool playBasketSound = false;
    bool playGlassSound = false;
    public GameObject photos;

    // Update is called once per frame

    void Update()
    {
        
        if (gameStage == 1)
        {
            if (amIPlayer1 == true)
            {
                if(firstVideoOver == false) {
                    
                    StartCoroutine(InitialWait());

                
                StartCoroutine(WaitForMacron());
                    
                }


                if (correctAnswer == true)
                {
                    
                    if(i == 0)
                    {
                        if(playLightSound == false) {
                        SoundManager.PlaySound("light");
                            playLightSound = true;
                        }
                        i++;
                    }
                    turnOffLight = false;
                    lightManager.ChangeIntensity(8);
                    Debug.Log("Racoon");
                    correctAnswer = false;
                    gameStage++;
                }
            }
            if(amIPlayer1 == false)
            {
                if (firstVideoOver == false)
                {

                    StartCoroutine(InitialWait());
                    firstVideoOver = true;

                }
                codeSpawn.answer = "Usine";
                if(correctAnswer == true)
                {
                    
                    videoManager.StartVideo(myVideos[1]);
                    //launch animator root + pc j2
                    if(playPCSound == false) {
                    SoundManager.PlaySound("pc");
                        playPCSound = true;
                    }
                    myAnimators[0].SetBool("isTriggered", true);
                    myAnimators[1].SetBool("isTriggered", true);
                    correctAnswer = false;
                    gameStage++;
                }
            }
        }

        if (gameStage == 2)
        {
            if (amIPlayer1 == true)
            {
                codeSpawn.answer = "Triangle";
               
                if (correctAnswer == true)
                {
                    Debug.Log("ours");
                    //mettre l'animation de la porte
                    if(playDoorSound == false) { 
                    SoundManager.PlaySound("door");
                        playDoorSound = true;
                    }
                    myAnimators[2].SetBool("isTriggered", true);
                    correctAnswer = false;
                    gameStage++;
                }
            }
            if (amIPlayer1 == false)
            {
                codeSpawn.answer = "T";
                if (correctAnswer == true)
                {
                    //lancer l'anim de fuite
                    correctAnswer = false;
                    gameStage++;
                }
            }
        }

        if (gameStage == 3)
        {
            if (amIPlayer1 == true)
            {
                
                codeSpawn.answer = "Truc";
                if (correctAnswer == true)
                {
                    Debug.Log("Mamma mia");
                    //faire apparaître le PQ
                    myAnimators[3].SetBool("isTriggered", true);
                    correctAnswer = false;
                    gameStage++;
                }
            }
            if (amIPlayer1 == false)
            {
                codeSpawn.answer = "Parapluie";
                if (correctAnswer == true)
                {
                    //répare fuite
                    correctAnswer = false;
                    gameStage++;
                }
            }
        }

        if (gameStage == 4)
        {
            if (amIPlayer1 == true)
            {
                codeSpawn.answer = "Spaceship";
                if (correctAnswer == true)
                {
                    Debug.Log("Oh shit");
                    videoManager.StartVideo(myVideos[3]);
                    correctAnswer = false;
                    gameStage++;
                }
            }
            if (amIPlayer1 == false)
            {
                codeSpawn.answer = "Pacman";
                if (correctAnswer == true)
                {
                    //lancer l'anim du ventilo et de la poubelle
                    if(playBasketSound == false) { 
                    SoundManager.PlaySound("basket");
                    SoundManager.PlaySound("fan");
                        playBasketSound = true;
                    }
                    photos.SetActive(true);
                    myAnimators[4].SetBool("isTriggered", true);
                    videoManager.StartVideo(myVideos[2]);
                    correctAnswer = false;
                    gameStage++;
                }
            }
        }

        if (gameStage == 5)
        {
            if (amIPlayer1 == true)
            {
                codeSpawn.answer = "Maison";
                if (correctAnswer == true)
                {
                    Debug.Log("Adibou");
                    //lancer l'anim de la plante
                    myAnimators[5].SetBool("isTriggered", true);
                    correctAnswer = false;
                    gameStage++;
                }
            }
            if (amIPlayer1 == false)
            {
                codeSpawn.answer = "M";
                if (correctAnswer == true)
                {
                    //anim fenetre
                    if(playGlassSound == false) {
                    SoundManager.PlaySound("glass");
                        playGlassSound = true;
                    }
                    myAnimators[6].SetBool("isTriggered", true);
                    videoManager.StartVideo(myVideos[4]);
                    correctAnswer = false;
                    gameStage++;
                }
            }
        }

        if (gameStage == 6)
        {
            if (amIPlayer1 == true)
            {
                codeSpawn.answer = "V";
                if (correctAnswer == true)
                {
                    videoManager.StartVideo(myVideos[5]);
                }
                StartCoroutine(EndVideo());
            }
            if (amIPlayer1 == false)
            {
                codeSpawn.answer = "V";
                if (correctAnswer == true)
                {
                    videoManager.StartVideo(myVideos[5]);
                    StartCoroutine(EndVideo());
                }
            }
        }

        IEnumerator InitialWait()
        {
            yield return new WaitForSeconds(5);
            videoManager.StartVideo(myVideos[0]);
        }

        IEnumerator WaitForMacron()
        {
            yield return new WaitForSeconds(45);
            
            firstVideoOver = true;
            codeSpawn.answer = "Fleche";
            if (turnOffLight == true) {
                if(playElecSound == false) { 
                SoundManager.PlaySound("elec");
                    playElecSound = true;
                }
                lightManager.ChangeIntensity(lightManager.lowestIntensity);

            }
            
        }
        IEnumerator EndVideo()
        {
            yield return new WaitForSeconds(45);

            loadingManager.LoadScene(0);

            

        }
    }

    

}
