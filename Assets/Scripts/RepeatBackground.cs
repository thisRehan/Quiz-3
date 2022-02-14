using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatBackground : MonoBehaviour
{
    private Vector3 startPosition;
    private float Width;

    private void Start()
    {
        startPosition = transform.position; // Establish the default starting position 
        Width = GetComponent<BoxCollider>().size.x/4; // Set repeat width to half of the background
    }

    private void Update()
    {
        Movement();
        Repeat();
    }
    public void Movement()
    {
        transform.Translate(Vector3.right * 2 * Time.deltaTime);
    }
    public void Repeat()// If background moves left by its repeat width, move it back to start position
    {
        if (transform.position.z < startPosition.z - Width)
        {
            transform.position = startPosition;
        }
    }
 
}


