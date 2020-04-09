using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawLines : MonoBehaviour
{
    public Vector3 pointA, pointB;
    public int lineWidth;
    RectTransform imageRectTransform;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void ImageShape(Vector3 pointA, Vector3 pointB)
    {
        imageRectTransform = GetComponent<RectTransform>();

        //transform.position = transform.parent.position;

        Vector3 differenceVector = (pointB - pointA) * GetComponentInParent<GridManager>().buttonSize;

        imageRectTransform.sizeDelta = new Vector2(differenceVector.magnitude, lineWidth);
        imageRectTransform.pivot = new Vector2(0, 0.5f);
        imageRectTransform.position = pointA * GetComponentInParent<GridManager>().buttonSize + transform.parent.position;
        float angle = Mathf.Atan2(differenceVector.y, differenceVector.x) * Mathf.Rad2Deg;
        imageRectTransform.rotation = Quaternion.Euler(0, 0, angle);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
