using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameFadeOutController : MonoBehaviour
{
    [SerializeField]
    private Image fadeImage;

    public bool fadeoutStarted;

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
            fadeImage.enabled = true;

            StartCoroutine(StartFadeOut());
        }
    }

    private IEnumerator StartFadeOut()
    {
        for (int i = 0; i <= 100; i++)
        {
            fadeImage.color = new Color(0, 0, 0, fadeImage.color.a + 0.01f);
            yield return new WaitForSecondsRealtime(0.017f);
        }

        yield return new WaitForSecondsRealtime(1f);
        LoadScene();
    }

    private void LoadScene()
    {
        SceneManager.LoadScene("ResultScene");
    }
}
