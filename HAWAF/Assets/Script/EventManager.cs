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
                    Debug.Log("Racoon");
                    lightManager.ChangeIntensity(lightManager.maxIntensity);
                    correctAnswer = false;
                    gameStage++;
                }
            }
            if(amIPlayer1 == false)
            {
                codeSpawn.answer = "Usine";
                if(correctAnswer == true)
                {
                    videoManager.StartVideo(myVideos[1]);
                    //launch animator root + pc j2
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
                    //mettre l'animation de la porte
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
                    SoundManager.PlaySound("basket");
                    SoundManager.PlaySound("fan");
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
                    myAnimators[6].SetBool("isTriggered", true);
                    videoManager.StartVideo(myVideos[4]);
                    correctAnswer = false;
                    gameStage++;
                }
            }
        }

        if (gameStage == 5)
        {
            if (amIPlayer1 == true)
            {
                codeSpawn.answer = "V";
                if (correctAnswer == true)
                {
                    loadingManager.LoadScene(finalSceneID);
                }
            }
            if (amIPlayer1 == false)
            {
                codeSpawn.answer = "V";
                if (correctAnswer == true)
                {
                    loadingManager.LoadScene(finalSceneID);
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
            lightManager.ChangeIntensity(lightManager.lowestIntensity);
            firstVideoOver = true;
            codeSpawn.answer = "Fleche";
        }
    }

    

}
