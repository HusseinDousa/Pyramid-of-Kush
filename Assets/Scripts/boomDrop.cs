using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boomDrop : MonoBehaviour
{

    public GameObject _boom;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.y == 0.5f)
        {
            Destroy(this.gameObject, 2.0f);
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Ground" )
        {
            Vector3 _instantiation = new Vector3(transform.position.x, transform.position.y, transform.position.z);
            Instantiate(_boom, _instantiation, Quaternion.identity);
        }

    }
}
