using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameFadeInController : MonoBehaviour
{
    public bool fadeInStarted;

    [SerializeField]
    private Image fadeImage;


    // Use this for initialization
    void Start()
    {
        fadeImage = GetComponent<Image>();
        fadeInStarted = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (fadeInStarted)
        {
            fadeInStarted = false;
            StartCoroutine(StartFadeIn());
        }
    }


    private IEnumerator StartFadeIn()
    {

        for (int i = 100; i >= 0; i--)
        {
            fadeImage.color = new Color(0, 0, 0, fadeImage.color.a - 0.01f);
            yield return null;
        }

        fadeImage.enabled = false;
    }
}
