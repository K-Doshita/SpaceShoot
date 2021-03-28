using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraGyro : MonoBehaviour
{
    private Quaternion gyro;

    // Start is called before the first frame update
    void Start()
    {
        Input.gyro.enabled = true;
        //this.transform.localRotation = Quaternion.Euler(90, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        this.gyro = Input.gyro.attitude;

        this.transform.localRotation = Quaternion.Euler(90, 0, 0) * (new Quaternion(-gyro.x, -gyro.y, gyro.z, gyro.w));
    }
}
