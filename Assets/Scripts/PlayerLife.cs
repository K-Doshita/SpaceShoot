using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;
using System.Threading.Tasks;


public class PlayerLife : MonoBehaviour
{
    public int playerLife = 5;

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

            if(playerLife > 1)
            {
                playerLife--;
                lifeCounterText.text = "LIFE × " + playerLife;
                damagePanel.SetActive(false);
            }
            else if (playerLife <= 1)
            {
                Time.timeScale = 0f;
                await Task.Delay(TimeSpan.FromSeconds(1.2f));
                SceneManager.LoadScene("ResultScene");
            }
        }
    }
}
