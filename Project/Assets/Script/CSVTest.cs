using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class CSVTest : MonoBehaviour
{
    private List<Dictionary<string, object>> pointList; //This lists holds the content of our .csv file
    public string inputfile; //This is the name of the csv file we're using
    // Start is called before the first frame update
    void Start()
    {
        /*
        pointList = CSVReader.Read(inputfile);
        string county = name;
        object num = pointList[0][county];
        Debug.Log(num);
        num = pointList[1][county];
        Debug.Log(num);
        num = pointList[2][county];
        Debug.Log(num);
        */
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
