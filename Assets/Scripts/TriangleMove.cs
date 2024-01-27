using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriangleMove : MonoBehaviour
{

    
    public Transform pentagon;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 path = pentagon.position - transform.position;
        transform.position += (path.normalized)*Time.deltaTime*Constants.speed;
        print(Time.deltaTime);
    }
}
