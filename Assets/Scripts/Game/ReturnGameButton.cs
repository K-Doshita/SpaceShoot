using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReturnGameButton : MonoBehaviour
{
    public GameObject pauseCanvas;

    public GameObject countdownText;

    public CountdownTimer countdownTimer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void OnClick_ReturnGameButton()
    {
        pauseCanvas.SetActive(false);

        countdownText.SetActive(true);

        countdownTimer.Countdown();

    }


   
}
