using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class waterCoolingSound : MonoBehaviour
{
    private bool waterActive = false;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !waterActive)
        {
            StartCoroutine(Sound());
            waterActive = true;
        }
    }

    IEnumerator Sound()
    {
        SoundManager.PlaySound("water");
        yield return new WaitForSeconds(11);
        waterActive = false;
    }
}
