using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartRotaion : MonoBehaviour
{
    [SerializeField]
    private GameObject calibrationUI;

    public static Quaternion ini_gyro;
    // Start is called before the first frame update
    void Start()
    {
        calibrationUI.SetActive(true);
        Input.gyro.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.gyro.enabled)
        {
            ini_gyro = Input.gyro.attitude;
            this.transform.localRotation = Quaternion.Euler(90, 0, 0) * (new Quaternion(-ini_gyro.x, -ini_gyro.y, ini_gyro.z, ini_gyro.w));
        }
    }

}
