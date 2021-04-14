using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Threading.Tasks;

public class ResultSceneManager : MonoBehaviour
{
    [SerializeField]
    private GameObject resultTextBox;
    [SerializeField]
    private GameObject resultTitleText;

    [SerializeField]
    private GameObject resultButton;

    [SerializeField]
    private GameObject resultPoint;
    private Text resultPointText;

    [SerializeField]
    private GameObject resultRank;

    private int gamePoint = 0;

    // Start is called before the first frame update
    void Start()
    {
        resultPointText = resultPoint.GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OverRideScore()
    {
        gamePoint = PointManager.GetTotalPoint();
        resultPointText.text = gamePoint.ToString();
    }


    public async void ResultTextBoxDown()
    {
        resultTextBox.SetActive(true);

        await Task.Delay(TimeSpan.FromSeconds(1.0f));

        resultTitleText.SetActive(true);

        await Task.Delay(TimeSpan.FromSeconds(0.5f));

        ActiveScore();
    }

    private async void ActiveScore()
    {
        resultPoint.SetActive(true);

        await Task.Delay(TimeSpan.FromSeconds(0.5f));

        resultRank.SetActive(true);

        await Task.Delay(TimeSpan.FromSeconds(0.5f));

        ResultButtonUp();
    }


    private void ResultButtonUp()
    {
        resultButton.SetActive(true);
    }
}
