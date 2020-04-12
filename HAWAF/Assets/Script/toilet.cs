using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class toilet : MonoBehaviour
{
    private bool washActive = false;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !washActive)
        {
            StartCoroutine(Sound());
            washActive = true;
        }
    }

    IEnumerator Sound()
    {
        SoundManager.PlaySound("flush");
        yield return new WaitForSeconds(5);
        washActive = false;
    }
}
