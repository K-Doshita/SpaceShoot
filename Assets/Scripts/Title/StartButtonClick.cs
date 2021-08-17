using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartButtonClick : MonoBehaviour
{
    [SerializeField]
    private GameObject startCanvas;

    [SerializeField]
    private TitleFadeOutController titleFadeOutController;

    [SerializeField]
    private StartRaycast startRaycast;

    private StartCanvasController starCanvasController;

    public bool onSphere;

    // Start is called before the first frame update
    void Start()
    {
        starCanvasController = startCanvas.GetComponent<StartCanvasController>();
        titleFadeOutController = titleFadeOutController.GetComponent<TitleFadeOutController>();
        startRaycast = startRaycast.GetComponent<StartRaycast>();
    }

    public void OnClick_StartButton()
    {
        if (onSphere == true)
        {
            titleFadeOutController.fadeoutStarted = true;
        }
        else if(onSphere == false && startRaycast.enabled == false)
        {
            starCanvasController.FadeOutBackGround();
        }
    }
}
