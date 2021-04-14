using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResultFadeInController : MonoBehaviour
{
    private float fadespeed = 0.01f;
    private float red, green, blue, alpha;

    public bool isFadeIn = true;

    private Image fadeImage;

    [SerializeField]
    private ResultSceneManager resultSceneManager;


    // Use this for initialization
    void Start()
    {

        fadeImage = GetComponent<Image>();

        red = fadeImage.color.r;
        green = fadeImage.color.g;
        blue = fadeImage.color.b;
        alpha = fadeImage.color.a;

    }

    // Update is called once per frame
    void Update()
    {
        if (isFadeIn)
        {
            StartFadeIn();
        }
    }

    /// <summary>
    /// ImageのAlpha値を徐々に下げてフェードを実施
    /// </summary>
    void StartFadeIn()
    {

        alpha -= fadespeed;
        SetAlpha();

        if (alpha <= 0)
        {
            isFadeIn = false;
            fadeImage.enabled = false;
            resultSceneManager.ResultTextBoxDown();
        }
    }

    /// <summary>
    /// alpha値をImageに反映
    /// </summary>
    void SetAlpha()
    {
        fadeImage.color = new Color(red, green, blue, alpha);
    }
}
