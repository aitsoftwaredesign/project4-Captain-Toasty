using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Globalization;

public class countyExtruder : MonoBehaviour
{
    Vector3 originalPosition; //This is used so we can swap between two different heights by scaling.
    public float dataValue; //This is the data we pull from the csv file and convert to height.
    public float dataHeight; //This the height in pixels our data corresponds to.

    bool shrinking; //Used to determine whether it's expanding or shrinking.
    Vector3 increasePos; //This is used to move the county up to match the scaling. It's how much we move it upeach tic
    Vector3 increaseScale; //How much the county scales each tic.
    Vector3 pos; //Used to hold the county's current position

    public bool randomScale; //Used to check if the county remains static or scales up and down.
    string countyName; //The name of the county, same as it's database entry.
    public GameObject ireland; //The gameobject of the whole map, which contains a script we reference.

    private List<Dictionary<string, object>> pointList; //This list of dictionaries holds the content of our .csv file
    public string inputfile; //This is the name of the csv file we're using

    // Start is called before the first frame update
    void Start()
    {
        inputfile = "Area of Selected Crops"; //This is the CSV file we're reading in.
        shrinking = false;
        //For every hundred pixels we scale we need to move it up 1 pixels to get a smooth transition.
        increaseScale = new Vector3(0.0f, 0.0f, 0.1f);
        increasePos = new Vector3(0.0f, 0.001f, 0.0f);

        pos = transform.position;
        randomScale = false;
        pointList = CSVReader.Read(inputfile); //We call another function to convert the .csv file into a dictionary list.
        originalPosition = this.transform.position;
        countyName = name;

        dataValue = getCSVData(0);
        dataHeight = convertToHeight(dataValue);    
        
    }
    //This function will get the corresponding value from the CSV database: we can use this to get a county's entry from many years.
    float getCSVData(int row)
    {
        object result = pointList[row][countyName];
        float num = (float)(int)result;
        float data = (num);
        return data;
    }
    //We can't use the raw data from the csv in the map: it would create very tall counties. We need to decrease it.
    float convertToHeight(float value)
    {
        return value / 10000;
    }
    //This function will enlarge and shrink the function between two values.
    void randomExtruding()
    {
        pos = transform.position;

        //Scale : Position = 100 : 1
        if (!shrinking)
        {
            this.transform.localScale += increaseScale;
            this.transform.position += increasePos;
        }
        else if (shrinking)
        {
            this.transform.localScale -= increaseScale;
            this.transform.position -= increasePos;
        }
        if (pos.y >= dataHeight)
        {
            shrinking = true;
        }
        else if (pos.y <= originalPosition.y)
        {
            shrinking = false;
        }
    }
    void scaleToValue()
    {
        Vector3 newPosition = this.transform.position;
        newPosition.y = dataHeight;
        this.transform.position = newPosition;

        Vector3 newScale = this.transform.localScale;
        newScale.z = dataHeight * 100;
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
