using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartButtonClick : MonoBehaviour
{
    [SerializeField]
    private GameObject startCanvas;

    [SerializeField]
    private TitleFadeOutController titleFadeOutController;

    private StarCanvasController starCanvasController;

    public bool onSphere;

    // Start is called before the first frame update
    void Start()
    {
        starCanvasController = startCanvas.GetComponent<StarCanvasController>();
        titleFadeOutController = titleFadeOutController.GetComponent<TitleFadeOutController>();
    }

    public void OnClick_StartButton()
    {
        if (onSphere == true)
        {
            titleFadeOutController.StartFade();
        }
        else
        {
            starCanvasController.FadeOutBackGround();
        }
    }
}
