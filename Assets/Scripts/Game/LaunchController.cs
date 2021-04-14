using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaunchController : MonoBehaviour
{
    [SerializeField]
    private GameObject bulletPrefab;
    [SerializeField]
    private Transform muzzlePoint;
    [SerializeField]
    private AudioSource shotAudio;

    private float shotSpeed = 5000f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClick_ShotBUtton()
    {
        GameObject bullet = GameObject.Instantiate(bulletPrefab, muzzlePoint.position, muzzlePoint.rotation);
        bullet.GetComponent<Rigidbody>().AddForce(bullet.transform.forward * shotSpeed);

        shotAudio.Play();

    }
    
}
