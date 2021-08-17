using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletForce : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //Vector3 vector3 = this.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        //transform.position += new Vector3(0, 0, 3);
        transform.position += transform.forward * 5f * Time.deltaTime;
    }
}
