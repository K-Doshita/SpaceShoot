using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Threading.Tasks;

public class StarCanvasController : MonoBehaviour
{
    [SerializeField]
    private GameObject backGround;
    [SerializeField]
    private Transform backGroundTransform;

    [SerializeField]
    private GameObject firstExplanation;
    [SerializeField]
    private GameObject secondExplanation;
    [SerializeField]
    private GameObject startButton;

    [SerializeField]
    private StartRotaion startRotaion;
    [SerializeField]
    private StartRaycast startRaycast;

    private Vector3 scale;

    private float backFadeSpeed = 0.2f;

    private bool firstClick;

    public GameObject startSphere;

    // Start is called before the first frame update
    void Start()
    {
        backGroundTransform = backGroundTransform.GetComponent<Transform>();

        startRotaion = startRotaion.GetComponent<StartRotaion>();
        startRaycast = startRaycast.GetComponent<StartRaycast>();

        scale = backGroundTransform.transform.localScale;

        firstClick = false;
        backGround.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public async void FadeInBackGround()
    {
        if (firstClick == false)
        {
            backGround.SetActive(true);
        }

        while (scale.x < 1 || scale.y < 1)
        {
            scale.x += backFadeSpeed;
            scale.y += backFadeSpeed;

            SetScale();

            await Task.Delay(TimeSpan.FromMilliseconds(1.0f));
        }

        if (firstClick == true)
        {
            secondExplanation.SetActive(true);
        }
        else if (firstClick == false)
        {
            firstExplanation.SetActive(true);
        }
        startButton.SetActive(true);
    }

    public async void FadeOutBackGround()
    {
        if (firstClick == false)
        {
            firstExplanation.SetActive(false);
        }
        else if (firstClick == true)
        {
            secondExplanation.SetActive(false);
        }

        while (scale.x >= 0 || scale.y >= 0)
        {
            scale.x -= backFadeSpeed;
            scale.y -= backFadeSpeed;

            SetScale();

            await Task.Delay(TimeSpan.FromMilliseconds(1.0f));
        }

        if (firstClick == false)
        {
            firstClick = true;

            await Task.Delay(TimeSpan.FromSeconds(0.1f));

            FadeInBackGround();
        }
        else if (firstClick == true)
        {
            firstClick = false;
            backGround.SetActive(false);
            startButton.SetActive(false);

            startRotaion.enabled = true;
            startRaycast.enabled = true;

            startSphere.SetActive(true);
        }
    }

    private void SetScale()
    {
        backGroundTransform.localScale = new Vector3(scale.x, scale.y, 1);
    }
}
