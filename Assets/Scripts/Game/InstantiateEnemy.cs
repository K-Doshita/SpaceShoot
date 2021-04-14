using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateEnemy : MonoBehaviour
{
    [SerializeField]
    private GameObject player;
    [SerializeField]
    private Transform playerTransform;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        playerTransform = player.GetComponent<Transform>();

        transform.LookAt(playerTransform);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
