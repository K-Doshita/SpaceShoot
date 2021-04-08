using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Threading.Tasks;

public class TitleClick : MonoBehaviour
{
    [SerializeField]
    private Text titleText;
    [SerializeField]
    private Text titleBackText;
    [SerializeField]
    private Text dotText;

    [SerializeField]
    private StarCanvasController starCanvasController;

    private float fadeSpeed = 0.1f;

    private float titleRed, titleGreen, titleBlue, titleAlpha;
    private float titleBackRed, titleBackGreen, titleBackBlue, titleBackAlpha;
    private float dotRed, dotGreen, dotBlue, dotAlpha;


    // Start is called before the first frame update
    void Start()
    {
        titleText = titleText.GetComponent<Text>();
        titleRed = titleText.color.r;
        titleGreen = titleText.color.g;
        titleBlue = titleText.color.b;
        titleAlpha = titleText.color.a;

        titleBackText = titleBackText.GetComponent<Text>();
        titleBackRed = titleBackText.color.r;
        titleBackGreen = titleBackText.color.g;
        titleBackBlue = titleBackText.color.b;
        titleBackAlpha = titleBackText.color.a;

        dotText = dotText.GetComponent<Text>();
        dotRed = dotText.color.r;
        dotGreen = dotText.color.g;
        dotBlue = dotText.color.b;
        dotAlpha = dotText.color.a;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public async void OnClick_TitlePanel()
    {
        while (titleAlpha >= 0 || dotAlpha >= 0 || titleBackAlpha >= 0)
        {
            titleAlpha -= fadeSpeed;
            titleBackAlpha -= fadeSpeed;
            dotAlpha -= fadeSpeed;
            
            SetAlpha();

            await Task.Delay(TimeSpan.FromMilliseconds(1.0f));
        }
        await Task.Delay(TimeSpan.FromSeconds(0.25f));

        starCanvasController.FadeInBackGround();

        this.gameObject.SetActive(false);
    }

    private void SetAlpha()
    {
        titleText.color = new Color(titleRed, titleGreen, titleBlue, titleAlpha);
        titleBackText.color = new Color(titleBackRed, titleBackGreen, titleBackBlue, titleBackAlpha);
        dotText.color = new Color(dotRed, dotGreen, dotBlue, dotAlpha);
    }
}
