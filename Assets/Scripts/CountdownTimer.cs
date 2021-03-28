using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Threading.Tasks;

public class CountdownTimer : MonoBehaviour
{
    
    public GameObject countdownCanvas;

    public Text countdownText;

    private int countdownNum;


    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public async void Countdown()
    {

        countdownText = countdownText.GetComponent<Text>();
        
        countdownNum = 3;
        countdownText.text = countdownNum.ToString();

        //countdownCanvas.SetActive(true);
        //StartCoroutine("CountdownInter");
        while(countdownNum > 1)
        {
            await Task.Delay(TimeSpan.FromSeconds(1));
            Debug.Log(countdownNum);


            --countdownNum;
            countdownText.text = countdownNum.ToString();
        }

        await Task.Delay(TimeSpan.FromSeconds(1));
        countdownText.text = null;

        countdownCanvas.SetActive(false);
        Time.timeScale = 1f;
    }


    /*private IEnumerator CountdownInter()
    {

    }*/
}
