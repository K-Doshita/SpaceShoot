using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartButtonClick : MonoBehaviour
{
    [SerializeField]
    private GameObject startCanvas;

    private StarCanvasController starCanvasController;

    // Start is called before the first frame update
    void Start()
    {
        starCanvasController = startCanvas.GetComponent<StarCanvasController>();
    }

    public void OnClick_StartButton()
    {
        starCanvasController.FadeOutBackGround();
    }
}
