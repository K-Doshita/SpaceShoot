using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class TitleFadeOutController : MonoBehaviour
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
            StartCoroutine(StartFadeOut());
        }
    }

    private IEnumerator StartFadeOut()
    {
        for (int i = 0; i <= 5; i++)
        {
            fadeImage.color = new Color(0, 0, 0, fadeImage.color.a + 0.2f);
            yield return null;
        }

        LoadScene();
    }

    private void LoadScene()
    {
        SceneManager.LoadScene("GameScene");
    }
}
