using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartRotaion : MonoBehaviour
{
    public GUIStyle labelStyle;
    public static Quaternion ini_gyro;
    // Start is called before the first frame update
    void Start()
    {
        this.labelStyle = new GUIStyle();
        this.labelStyle.fontSize = Screen.height / 22;
        this.labelStyle.normal.textColor = Color.white;
    }

    // Update is called once per frame
    void Update()
    {
        Input.gyro.enabled = true;
        if (Input.gyro.enabled)
        {
            ini_gyro = Input.gyro.attitude;
            this.transform.localRotation = Quaternion.Euler(90, 0, 0) * (new Quaternion(-ini_gyro.x, -ini_gyro.y, ini_gyro.z, ini_gyro.w));
        }
    }

}
