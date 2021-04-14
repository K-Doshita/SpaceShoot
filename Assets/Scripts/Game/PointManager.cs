using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PointManager : MonoBehaviour
{
    public static int currentPoint;

    public Text pointText;

    // Start is called before the first frame update
    void Start()
    {
        pointText.text = "POINT\n00";
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddPoint(int addPoint)
    {
        currentPoint += addPoint;

        if (currentPoint <= 9)
        {
            pointText.text = "POINT\n0" + currentPoint;
        }
        else if(currentPoint >= 10)
        {
            pointText.text = "POINT\n" + currentPoint;
        }
    }


    public static int GetTotalPoint()
    {
        return currentPoint;
    }
}
