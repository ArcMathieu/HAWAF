using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Glowing : MonoBehaviour
{
    public bool isHighlighted = false;
    public Shader unlitShader;
    public Shader litShader;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       if (!isHighlighted)
        {
            GetComponent<Renderer>().material.shader = unlitShader;
        } else
        {
            GetComponent<Renderer>().material.shader = litShader;
        }
    }

    private void LateUpdate()
    {
        isHighlighted = false;
    }
}
