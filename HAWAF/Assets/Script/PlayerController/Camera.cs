using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Vector3 forward = transform.TransformDirection(Vector3.forward);
        RaycastHit rc;
        if (Physics.Raycast (transform.position, forward, out rc, 100))
        {
            if (rc.collider.gameObject.tag == "UsableObjects")
            {
                rc.collider.gameObject.GetComponent<Glowing>().isHighlighted = true;
            }
        }
    }

    void Move()
    {
        transform.Rotate(new Vector3(-Input.GetAxis("Mouse Y"), 0, 0) * Time.deltaTime * GameManager._instance.playerRotationSpeed);
    }
}
