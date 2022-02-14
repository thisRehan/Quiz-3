using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private GameObject animalClone;
    Rigidbody playerRb;
    private GameObject Animal;
    private Transform child;
    private int speed = 2;
    private int forceAlongYAxiz = 5;
    private int forceAlongZAxiz = 5;
    public bool isAlive;
    // Start is called before the first frame update
    void Start()
    {
        Animal = GameObject.Find("Animal");
        playerRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Movement(speed);
    }
    public void Movement(int speed)
    {
        Jump(forceAlongYAxiz, forceAlongZAxiz);
        float horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * speed * Time.deltaTime * horizontalInput);
    }
    void Jump(int yForce, int zForce)
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            animalClone = GameObject.Find("SpawnManager").GetComponent<SpawnManager>().animalClone;
            if (Animal.transform.parent != null)
                Animal.transform.parent = null;
            if(animalClone.transform.parent != null)
                animalClone.transform.parent = null;
            playerRb.AddRelativeForce(0, yForce, zForce, ForceMode.Impulse);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
          // PlayerFellDown();
        }
        if (collision.gameObject.CompareTag("Animal"))
        {
            animalClone = GameObject.Find("SpawnManager").GetComponent<SpawnManager>().animalClone;
            if(animalClone != null)
                animalClone.transform.parent = transform;
        }
    }
    void PlayerFellDown()
    {
        speed = 0;
        forceAlongYAxiz = 0;
        forceAlongZAxiz = 0;
    }
}
