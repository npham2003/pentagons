using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using static MelodyModel;


public class Spawner : MonoBehaviour
{
    public GameObject trianglePrefab;
    public GameObject newTriangle;

 

    [SerializeField]
    private float moveSpeed = 1;
    public static KeyValuePair<Color, int> randomTriangle;
    public GameObject pentagon;
    public Dictionary<Color, int> possibleTriangles;
    public Color triangleColor;
   


    public int[] melody = new int[5];
    public int iter=0;
    // Start is called before the first frame update
    void Start()
    {
        possibleTriangles = new Dictionary<Color, int>()
        {
            { new Color(90/255f, 181/255f, 255/255f, 1f), 0 },
            { new Color(255/255f, 186/255f, 244/255f, 1f), 1},
            { new Color(237/255f, 116/255f, 71/255f, 1f), 2 },
            { new Color(220/255f, 232/255f, 209/255f, 1f), 3},
            { new Color(255/255f, 224/255f, 90/255f, 1f), 4}

        };

        

        
    }

    private void GenerateNewMelody(){
        for (int i=0;i<melody.Length;i++){
            melody[i]=UnityEngine.Random.Range(0,5);
        }
    }
    // Update is called once per frame
    public void CorrectPickup()
    {
        iter+=1;
        iter=iter%5;
        if(iter==0){
            GenerateNewMelody();
        }
    }

    public void Spawn(){
        float x = UnityEngine.Random.Range(-10,10);
        transform.position = new Vector3(x,-5.5f,0);
        newTriangle = Instantiate(trianglePrefab, transform);
        randomTriangle = GetRandomTriangle();
        triangleColor = randomTriangle.Key;
        SpriteRenderer triangleRenderer = newTriangle.GetComponentInChildren<SpriteRenderer>();
        if(triangleRenderer != null)
        {
            triangleRenderer.color = triangleColor;
        }
        // newTriangle.transform.position = transform.position;
        TriangleMove moveScript = newTriangle.GetComponent<TriangleMove>();
        moveScript.Setup(transform.position, moveSpeed, pentagon, this);
        
        // moveScript.speed=moveSpeed;
        // moveScript.pentagon=pentagon;
        // moveScript.path = pentagon.transform.position - transform.position;
        // newTriangle.transform.LookAt(pentagon.transform);
   
        
        
    }


    public KeyValuePair<Color, int> GetRandomTriangle()
    {
        int randomIndex = UnityEngine.Random.Range(0, possibleTriangles.Count);
        Color randomKey = new List<Color>(possibleTriangles.Keys)[randomIndex];
        return new KeyValuePair<Color, int>(randomKey, possibleTriangles[randomKey]);
    }
}
