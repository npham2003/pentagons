using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject trianglePrefab;
    [SerializeField]
    private Boolean canSpawn = true;

    [SerializeField]
    private float moveSpeed = 1;

    public GameObject pentagon;
    // Start is called before the first frame update
    void Start()
    {
        Spawn();
    }

    // Update is called once per frame
    void Update()
    {
        

    }

    public void Spawn(){
        float x = UnityEngine.Random.Range(-10,10);
        transform.position = new Vector3(x,-5.5f,0);
        GameObject newTriangle = Instantiate(trianglePrefab, transform);
        // newTriangle.transform.position = transform.position;
        TriangleMove moveScript = newTriangle.GetComponent<TriangleMove>();
        moveScript.Setup(transform.position, moveSpeed, pentagon, this);
        
        // moveScript.speed=moveSpeed;
        // moveScript.pentagon=pentagon;
        // moveScript.path = pentagon.transform.position - transform.position;
        // newTriangle.transform.LookAt(pentagon.transform);
        print(newTriangle.transform.position);
        canSpawn=false;
    }
}
