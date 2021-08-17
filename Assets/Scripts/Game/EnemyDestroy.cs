using System.Collections;
using UnityEngine;
using System;
using System.Threading.Tasks;

public class EnemyDestroy : MonoBehaviour
{
    private ParticleSystem explosion;

    private GameObject explosionPrefab;

    private GameObject[] childObject;

    private GameObject enemyBody;

    private Collider enemyCollider;

    private PointManager pointManager;
    private GameObject pointObject;

    private Animator fadeAnim;

    [SerializeField]
    private AudioSource destroyAudio;


    // Start is called before the first frame update
    void Start()
    {
        childObject = new GameObject[2];

        GetAllChildObject();

        enemyBody = childObject[0];
        explosionPrefab = childObject[1];

        explosion = explosionPrefab.GetComponent<ParticleSystem>();

        enemyCollider = GetComponent<BoxCollider>();
        enemyCollider.enabled = true;

        pointObject = GameObject.Find("PointCounter");
        pointManager = pointObject.GetComponent<PointManager>();

        fadeAnim = GetComponent<Animator>();

        //destroyAudio = GetComponent<AudioSource>();
    }

    private void GetAllChildObject()
    {
        childObject = new GameObject[this.gameObject.transform.childCount];

        for (int i = 0; i < 2; ++i)
        {
            childObject[i] = this.gameObject.transform.GetChild(i).gameObject;
        }
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag("Bullet"))
        {
            enemyCollider.enabled = false;
            pointManager.AddPoint(1);
            DestroyEnemy();

        }
    }

    private void DestroyEnemy()
    {
        explosion.Play();
        destroyAudio.Play();
        ExplosionEnemy();

    }

    private async void ExplosionEnemy()
    {
        await Task.Delay(TimeSpan.FromSeconds(0.7f));

        Destroy(enemyBody);

        await Task.Delay(TimeSpan.FromSeconds(1.2));

        Destroy(explosionPrefab);
        Destroy(this.gameObject);

    }




    public async void Fadeout()
    {
        fadeAnim.SetBool("Fade", true);

        await Task.Delay(TimeSpan.FromSeconds(1.2f));

        Destroy(this.gameObject);

    }
}
