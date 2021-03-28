using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseButton : MonoBehaviour
{
    public GameObject pauseCanvas;


    // Start is called before the first frame update
    void Start()
    {
        pauseCanvas.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void OnClick_PauseButton()
    {
        pauseCanvas.SetActive(true);
        Time.timeScale = 0f;
    }
}
