using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CodeSpawn : MonoBehaviour
{
    public GameObject codeUI;
    public GridManager gridManager;
    public string answer;
    public EventManager eventManager;
    public bool active = false;
    public bool inZone = false;
    private void Start()
    {
        Cursor.visible = false;
        codeUI.SetActive(false);
        gridManager.answer = "none";
    }
    private void OnTriggerStay(Collider other)
    {
        if (eventManager.firstVideoOver == true)
        {
            if (other.CompareTag("Player"))
            {
                Cursor.visible = true;
                codeUI.SetActive(true);
                gridManager.answer = answer;

            }
            
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            gridManager.Restart();
            Cursor.visible = false;
            gridManager.answer = "none";
            codeUI.SetActive(false);
        }
    }
}
