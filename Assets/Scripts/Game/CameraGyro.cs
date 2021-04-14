using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraGyro : MonoBehaviour
{
    private Quaternion gyro;

    private Quaternion startGyro;
    // Start is called before the first frame update
    void Start()
    {
        Input.gyro.enabled = true;
        startGyro = StartRotaion.ini_gyro;

    }

    // Update is called once per frame
    void Update()
    {
        gyro = Input.gyro.attitude;

        gyro = Quaternion.Euler(90, 0, 0) * new Quaternion(-gyro.x, -gyro.y, gyro.z, gyro.w);

        this.transform.localRotation = Quaternion.Euler(0, -startGyro.y, 0) * gyro;
    }
}
