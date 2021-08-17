using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    [SerializeField]
    private GameObject bulletPrefab;

    private int shootCount;

    private EnemyDestroy enemyDestroy;

    // Start is called before the first frame update
    void Start()
    {
        EnemyShot();

        enemyDestroy = this.gameObject.transform.parent.parent.GetComponent<EnemyDestroy>();
    }

    // Update is called once per frame
    void Update()
    {

    }


    private void EnemyShot()
    {

        InvokeRepeating("InstantiateBullet", 5f, 5f);
    }


    public void InstantiateBullet()
    {
        GameObject bullet = GameObject.Instantiate(bulletPrefab, this.gameObject.transform.position, this.gameObject.transform.rotation);
        //bullet.GetComponent<Rigidbody>().AddForce(bullet.transform.forward * shotSpeed);

        shootCount++;

        if (shootCount >= 3)
        {
            CancelInvoke("InstantiateBullet");
            enemyDestroy.Fadeout();
        }
    }
}
