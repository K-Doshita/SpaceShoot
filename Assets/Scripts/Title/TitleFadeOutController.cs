using UnityEngine.UI;
using UnityEngine;
using System;
using System.Threading.Tasks;
using UnityEngine.SceneManagement;

public class TitleFadeOutController : MonoBehaviour
{
    
    private Image fadeImage;


    private float fadeSpeed = 0.2f;
    [SerializeField]
    private float red, green, blue, alpha;

    // Start is called before the first frame update
    void Start()
    {
        fadeImage = GetComponent<Image>();
        red = fadeImage.color.r;
        green = fadeImage.color.g;
        blue = fadeImage.color.b;
        alpha = fadeImage.color.a;

        fadeImage.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public async void StartFade()
    {
        fadeImage.enabled = true;

        while (alpha <= 1)
        {

            alpha += fadeSpeed;
            SetAlpha();

            await Task.Delay(TimeSpan.FromMilliseconds(1.0f));
        }


        LoadScene();
    }

    private void SetAlpha()
    {
        fadeImage.color = new Color(red, green, blue, alpha);
    }

    private async void LoadScene()
    {
        await Task.Delay(TimeSpan.FromSeconds(1.0f));
        SceneManager.LoadScene("GameScene");
    }
}
