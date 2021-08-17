using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneLoadManager : MonoBehaviour
{
    [SerializeField]
    private Image fadeImage;

    private bool fadeoutStarted;


    // Start is called before the first frame update
    void Start()
    {
        fadeoutStarted = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (fadeoutStarted)
        {
            fadeoutStarted = false;
            StartCoroutine(StartFadeOut());
        }
    }

    private IEnumerator StartFadeOut()
    {
        for(int i = 0; i <= 5; i++)
        {
            fadeImage.color = new Color(0, 0, 0, fadeImage.color.a + 0.2f);
            yield return null;
        }
    }

    public void Onclick_ReturnGameScene()
    {
        fadeoutStarted = true;
        fadeImage.enabled = true;

        StartCoroutine(LoadScene("GameScene"));
    }


    public void Onclick_ReturnTitle()
    {
        fadeoutStarted = true;
        fadeImage.enabled = true;

        StartCoroutine(LoadScene("TitleScene"));
    }


    private IEnumerator LoadScene(string scene)
    {
        yield return new WaitForSeconds(0.5f);

        SceneManager.LoadScene(scene);
    }
}
