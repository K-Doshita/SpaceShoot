using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Threading.Tasks;

public class EnemyBulletDestroy : MonoBehaviour
{
    private ParticleSystem explosion;
    private GameObject explosionPrefab;

    private GameObject[] childObject;

    private GameObject enemyBody;
    private Collider enemyCollider;

    // Start is called before the first frame update
    void Start()
    {
        childObject = new GameObject[2];

        GetAllChildObject();

        enemyBody = childObject[0];
        explosionPrefab = childObject[1];

        explosion = explosionPrefab.GetComponent<ParticleSystem>();

        enemyCollider = GetComponent<SphereCollider>();
        enemyCollider.enabled = true;
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

            DestroyEnemyBullet();
        }
        else if (other.gameObject.CompareTag("Player"))
        {
            enemyCollider.enabled = false;

            Destroy(gameObject);
        }
    }



    private async void DestroyEnemyBullet()
    {
        explosion.Play();

        await Task.Delay(TimeSpan.FromSeconds(0.7f));

        Destroy(enemyBody);

        await Task.Delay(TimeSpan.FromSeconds(1.2f));

        Destroy(explosionPrefab);
        Destroy(gameObject);
    }
}
