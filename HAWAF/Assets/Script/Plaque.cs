using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plaque : MonoBehaviour
{
    public VideoManager videoManager;
    public LightManager lightManager;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            //videoManager.StartVideo();
            lightManager.ChangeIntensity(lightManager.maxIntensity);
        }
    }
}
