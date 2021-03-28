using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    [SerializeField]
    private GameObject bulletPrefab;

    private float shotSpeed = 500f;

    private int shootCount = 0;

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

        InvokeRepeating("InstantiateBullet", 3f, 3f);
    }


    public void InstantiateBullet()
    {
        GameObject bullet = GameObject.Instantiate(bulletPrefab, this.gameObject.transform.position, this.gameObject.transform.rotation);
        bullet.GetComponent<Rigidbody>().AddForce(bullet.transform.forward * shotSpeed);

        shootCount++;

        if (shootCount >= 3)
        {
            CancelInvoke();
            enemyDestroy.Fadeout();
        }
    }
}
