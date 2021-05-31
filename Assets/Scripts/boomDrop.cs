using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boomDrop : MonoBehaviour
{

    public GameObject _boom;
    public float _projectileSpeed;
    [SerializeField]private Rigidbody _rb;

    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody>();

        if(_rb == null)
        {
            Debug.LogError("Rigidbody is null");
        }


    }

    // Update is called once per frame
    void Update()
    {

        _rb.AddForce(Vector3.forward * _projectileSpeed * Time.deltaTime);

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Ground" )
        {
            Vector3 _instantiation = new Vector3(transform.position.x, transform.position.y, transform.position.z);
            Instantiate(_boom, _instantiation, Quaternion.identity);

            Destroy(this.gameObject, 5.0f);
        }

    }
}
