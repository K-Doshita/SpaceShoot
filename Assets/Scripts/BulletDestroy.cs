using UnityEngine;

public class BulletDestroy : MonoBehaviour
{

    private new Collider collider;
    // Start is called before the first frame update
    void Start()
    {
        collider = GetComponent<SphereCollider>();
        collider.enabled = true;

        Destroy(this.gameObject, 5f);
        
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("enemy"))
        {
            collider.enabled = false;
            Destroy(this.gameObject);
        }
        
    }
}
