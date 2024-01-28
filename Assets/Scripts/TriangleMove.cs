using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEditor.Scripting;
using UnityEngine;

public class TriangleMove : MonoBehaviour
{

    
    public GameObject pentagon;
    public Vector3 path;
   
    
    private Spawner spawner;
    public float speed;
   

    // Start is called before the first frame update
    void Start()
    {
        

    }

    // Update is called once per frame
    void Update()
    {
        
        transform.position += (path.normalized)*Time.deltaTime*speed;
       
        if (transform.position.y>6){
            gameObject.SetActive(false);
            spawner.Spawn();
            Destroy(gameObject);
        }
    }

    public void Setup(Vector3 position, float sp, GameObject pent, Spawner manage){
        speed =sp;
        transform.position=position;
        pentagon = pent;
        path = pentagon.transform.position - transform.position;
        spawner=manage; 
    }
}
