using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public GameObject enemyPrefab;
    
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("InstantiateEnemy", 1f, 3f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void InstantiateEnemy()
    {
        GameObject enemy = Instantiate(enemyPrefab);
        enemy.transform.position = InstantiatePosition();
        enemy.transform.rotation = new Quaternion(0, 180, 0, 0);
    }

    private Vector3 InstantiatePosition()
    {
        float x = Random.Range(-50, 50);
        float y = Random.Range(-10, 10);
        float z = Random.Range(20, 30);

        return new Vector3(x, y, z);
    }
}
