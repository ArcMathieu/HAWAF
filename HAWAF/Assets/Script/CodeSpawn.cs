using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CodeSpawn : MonoBehaviour
{
    public GameObject codeUI;
    public GridManager gridManager;
    public string answer;
    public EventManager eventManager;
    private void Start()
    {
        gridManager.answer = "none";
    }
    private void OnTriggerEnter(Collider other)
    {
        if (eventManager.firstVideoOver == true) { 
        if (other.CompareTag ("Player"))
        {
            codeUI.SetActive(true);
            gridManager.answer = answer;
        }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            gridManager.answer = "none";
            codeUI.SetActive(false);
        }
    }
}
