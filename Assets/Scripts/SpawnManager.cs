using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] GameObject animal;
    public GameObject animalClone;
    private int spawnStart = 5;
    private int spawnDelay = 5;
    // Start is called before the first frame update
    void Start()
    {
        spawn();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void spawn()
    {
        animalClone = Instantiate(animal, randomPosition(), animal.transform.rotation);
    }
    Vector3 randomPosition()
    {
        float xPosition = 8;
        float xRandomPosition = Random.Range(-xPosition, xPosition);
        Vector3 position = new Vector3(xRandomPosition, 0, 0);
        return position;
    }
}
