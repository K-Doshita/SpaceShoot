using UnityEngine;
using UnityEngine.UI;
using System;
using System.Threading.Tasks;


public class PlayerLife : MonoBehaviour
{
    public int playerLife = 5;

    [SerializeField]
    private GameFadeOutController gameFadeOutController;
    [SerializeField]
    private GameObject damagePanel;
    private GameObject lifeCounter;
    private Text lifeCounterText;
    private new Collider collider;

    // Start is called before the first frame update
    void Start()
    {
        lifeCounter = GameObject.Find("LifeCounter");
        lifeCounterText = lifeCounter.GetComponent<Text>();

        collider = GetComponent<BoxCollider>();

        lifeCounterText.text = "LIFE × 5";
    }

    // Update is called once per frame
    void Update()
    {

    }

    private async void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("enemy"))
        {
            damagePanel.SetActive(true);
            await Task.Delay(TimeSpan.FromSeconds(0.05f));

            playerLife--;
            lifeCounterText.text = "LIFE × " + playerLife;

            if (playerLife > 0)
            {
                damagePanel.SetActive(false);
            }
            else if (playerLife <= 0)
            {
                Time.timeScale = 0f;
                gameFadeOutController.fadeoutStarted = true;
            }
        }
    }
}
