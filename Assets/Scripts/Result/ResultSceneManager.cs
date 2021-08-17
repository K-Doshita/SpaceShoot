using UnityEngine;
using UnityEngine.UI;
using System;
using System.Threading.Tasks;
using System.Threading;

public class ResultSceneManager : MonoBehaviour
{
    [SerializeField]
    private GameObject resultTextBox;
    [SerializeField]
    private Animator resultTextBoxDownAnim;

    [SerializeField]
    private GameObject resultTitleText;

    [SerializeField]
    private GameObject resultButton;

    [SerializeField]
    private GameObject resultPoint;
    private Text resultPointText;

    [SerializeField]
    private GameObject resultRank;
    private Text resultRankText;

    private int gamePoint = 0;

    private SynchronizationContext synchronizationContext;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1f;
        resultPointText = resultPoint.GetComponent<Text>();
        resultRankText = resultRank.GetComponent<Text>();
        synchronizationContext = SynchronizationContext.Current;

        OverRideScore();
        SelectRank(gamePoint);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OverRideScore()
    {
        gamePoint = PointManager.GetTotalPoint();
        resultPointText.text = gamePoint.ToString();
    }

    private void SelectRank(int points)
    {
        if(points < 20)
        {
            resultRankText.text = "e";
        }
        else if (20 <= points && points < 40)
        {
            resultRankText.text = "d";
        }
        else if (40 <= points && points < 60)
        {
            resultRankText.text = "c";
        }
        else if (60 <= points && points < 80)
        {
            resultRankText.text = "b";
        }
        else if (80 <= points && points < 100)
        {
            resultRankText.text = "a";
        }
        else if (100 <= points)
        {
            resultRankText.text = "s";
        }
    }


    public async void ResultTextBoxDown()
    {
        resultTextBox.SetActive(true);

        await Task.Delay(TimeSpan.FromSeconds(0.017f));
        
        resultTextBoxDownAnim.enabled = true;
        resultTextBoxDownAnim.SetBool("BoxDown", true);

        await Task.Delay(TimeSpan.FromSeconds(1.0f));

        resultTitleText.SetActive(true);

        await Task.Delay(TimeSpan.FromSeconds(0.5f));

        ActiveScore();
    }

    private async void ActiveScore()
    {
        resultPoint.SetActive(true);

        await Task.Delay(TimeSpan.FromSeconds(0.5f));

        resultRank.SetActive(true);

        await Task.Delay(TimeSpan.FromSeconds(0.5f));

        ResultButtonUp();
    }


    private void ResultButtonUp()
    {
        resultButton.SetActive(true);
    }
}
