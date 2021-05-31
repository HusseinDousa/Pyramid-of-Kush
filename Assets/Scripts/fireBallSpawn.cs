using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fireBallSpawn : MonoBehaviour
{
    public boomDrop _projectile;
    private float _fireBallSpawnTime = 7.0f;
    private bool _stopSpawn = false;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(fireBalls());


    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator fireBalls()
    {


        yield return new WaitForSeconds(5.0f);

        while (_stopSpawn == false)
        {
            // Randomize treasure prefab
            int prefab_num = Random.Range(0, 3);
                        
            Vector3 direction = new Vector3(Random.Range(35.0f, 55.0f), 10.0f, 20.0f);
            boomDrop newBall = Instantiate(_projectile, direction, transform.rotation);
            
         
            yield return new WaitForSeconds(_fireBallSpawnTime);
        }
    }
}
