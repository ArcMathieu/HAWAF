using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OnButton : MonoBehaviour
{
    private int actualButton;
    // Start is called before the first frame update
    void Start()
    {
        actualButton = GameManager._instance.buttonNumber;
        GameManager._instance.buttonNumber++;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void GetActualButton()
    {
        GetComponentInParent<GridManager>().GetProposition(actualButton);
        GetComponentInParent<GridManager>().DrawLine(actualButton);
        GetComponent<Image>().color = Color.red;
    }
}
