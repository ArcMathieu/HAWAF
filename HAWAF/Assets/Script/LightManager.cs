using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightManager : MonoBehaviour
{
    public Light[] myLights = new Light[1];
    public int arraySize;

    public float intensitySpeed = 1.0f;
    public float maxIntensity = 1.0f;
    
    float startTime;

    private void Start()
    {
        startTime = Time.time;
    }

    public void ChangeIntensity()
    {
        for(int i = 0; i<arraySize; i++) {
        myLights[i].intensity = maxIntensity;
        }
    }

}
