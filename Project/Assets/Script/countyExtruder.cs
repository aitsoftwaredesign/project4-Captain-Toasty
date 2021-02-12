using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class countyExtruder : MonoBehaviour
{
    Vector3 originalPosition;
    public float maxPosition;
    bool reverse;
    Vector3 increasePos;
    Vector3 increaseScale;
    Vector3 pos;
    public bool randomScale;
    // Start is called before the first frame update
    void Start()
    {
        originalPosition = this.transform.position;
        maxPosition = Random.Range(0.1f, 0.4f);
        reverse = false;
        increaseScale = new Vector3(0.0f, 0.0f, 0.1f);
        increasePos = new Vector3(0.0f, 0.001f, 0.0f);
        pos = transform.position;
        randomScale = false;
    }
    void randomExtruding()
    {
        pos = transform.position;

        //Scale : Position = 100 : 1
        if (!reverse)
        {
            this.transform.localScale += increaseScale;
            this.transform.position += increasePos;
        }
        else if (reverse)
        {
            this.transform.localScale -= increaseScale;
            this.transform.position -= increasePos;
        }
        if (pos.y >= maxPosition)
        {
            reverse = true;
        }
        else if (pos.y <= originalPosition.y)
        {
            reverse = false;
        }
    }
    void scaleToValue()
    {
        Vector3 newPosition = this.transform.position;
        newPosition.y = maxPosition;
        this.transform.position = newPosition;

        Vector3 newScale = this.transform.localScale;
        newScale.z = maxPosition * 100;
        this.transform.localScale = newScale;
    }
    // Update is called once per frame
    void Update()
    {
        if(randomScale)
        {
            randomExtruding();
        }
        else
        {
            scaleToValue();
        }
    }
}
