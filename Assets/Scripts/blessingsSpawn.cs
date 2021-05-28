using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class blessingsSpawn : MonoBehaviour
{

    public GameObject[] _blessings;
    private float _blessingSpawnTime = 3.0f;
    private bool _stopSpawn = false;

  
    // Start is called before the first frame update

    public void Awake()
    {
        StartCoroutine(treasureSpawn());

    }
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator treasureSpawn()
    {


        yield return new WaitForSeconds(5.0f);

        while(_stopSpawn == false)
        {
            // Randomize treasure prefab
            int prefab_num = Random.Range(0, 3);

            Vector3 direction = new Vector3(Random.Range(35.0f, 55.0f), 10.0f, 20.0f);
            GameObject newBlessing = Instantiate(_blessings[prefab_num], direction, Quaternion.Euler(-90f, 0.0f, 0.0f));

            yield return new WaitForSeconds(_blessingSpawnTime);
        }
    }

    public void _onPlayerDeath()
    {
        _stopSpawn = true;
    }
}
