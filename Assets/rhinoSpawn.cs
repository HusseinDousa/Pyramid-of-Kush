using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rhinoSpawn : MonoBehaviour
{
    public GameObject _Rhino;
    public float _rhinoSpawnTime = 5.0f;
    private bool _stopSpawn = false;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine( treasureSpawn());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator treasureSpawn()
    {


        yield return new WaitForSeconds(5.0f);

        while (_stopSpawn == false)
        {
            Vector3 _direction = new Vector3(transform.position.x, transform.position.y, transform.position.z);
            Instantiate(_Rhino, _direction, Quaternion.identity);

            yield return new WaitForSeconds(_rhinoSpawnTime);
        }
    }
}
