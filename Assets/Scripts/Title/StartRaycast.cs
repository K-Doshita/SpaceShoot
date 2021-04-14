using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartRaycast : MonoBehaviour
{
    [SerializeField]
    private StartButtonClick startButtonClick;

    // Start is called before the first frame update
    void Start()
    {
        startButtonClick = startButtonClick.GetComponent<StartButtonClick>();
        startButtonClick.onSphere = false;
    }

    // Update is called once per frame
    void Update()
    {
        
        Ray ray = new Ray(transform.position, transform.forward);


        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, Mathf.Infinity) && hit.collider.gameObject.CompareTag("Sphere"))
        {
            hit.collider.GetComponent<MeshRenderer>().material.color = Color.red;
            startButtonClick.onSphere = true;
        }
        else
        {
            startButtonClick.onSphere = false;
        }
    }
}
