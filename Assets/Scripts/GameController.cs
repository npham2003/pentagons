using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static MelodyModel;
using static PentagonController;
using static Spawner;


public class GameController : MonoBehaviour
{

    public enum PlayerState
    {
        none,
        start,
        playing,
        won,
        lost
    }

    //Triangles 
    public GameObject topCenterTri;
    public GameObject topRightTri;
    public GameObject topLeftTri;
    public GameObject BottomLeftTri;
    public GameObject BottomRightTri;


    public PlayerState player;
    public PentagonController pentagonController; 
    public Melody currentMelody;
    public Spawner triangle;

    private void OnEnable()
    {
        player = PlayerState.none; 
    }

    // Start is called before the first frame update
    void Start()
    {
        player = PlayerState.start;

    }

    // Update is called once per frame
    void Update()
    {
        
        //START STATE
        if(player == PlayerState.start)
        {
            currentMelody = GetRandomMelody();
            player = PlayerState.playing;

        }

        //PLAYING STATE
        if(player == PlayerState.playing)
        {
            //if triangle enters pentagon and player presses space check if the triangle is the correct one and activate the correct triangle on the pentagon
            if(currentCollisionObject != null && Input.GetKeyDown(KeyCode.Space))
            {
                Debug.Log("hit tri");
                KeyValuePair<Color, TriangleTone> currentKeyTriangle = currentMelody.triangles[0];
                if (randomTriangle.Key == currentKeyTriangle.Key)
                {
                    if (currentKeyTriangle.Key == currentMelody.triangles[0].Key)
                    {
                        topLeftTri.SetActive(true);
                        topLeftTri.GetComponent<SpriteRenderer>().color = currentKeyTriangle.Key;
                        currentKeyTriangle = currentMelody.triangles[1];
                     
                    }
                    else if (currentKeyTriangle.Key == currentMelody.triangles[1].Key)
                    {
                        topCenterTri.SetActive(true);
                        topCenterTri.GetComponent<SpriteRenderer>().color = currentKeyTriangle.Key;
                        currentKeyTriangle = currentMelody.triangles[2];
                     
                    }
                    else if (currentKeyTriangle.Key == currentMelody.triangles[2].Key)
                    {
                        topRightTri.SetActive(true);
                        topRightTri.GetComponent<SpriteRenderer>().color = currentKeyTriangle.Key;
                        currentKeyTriangle = currentMelody.triangles[3];
                        

                    }
                    else if (currentKeyTriangle.Key == currentMelody.triangles[3].Key)
                    {
                        BottomRightTri.SetActive(true);
                        BottomRightTri.GetComponent<SpriteRenderer>().color = currentKeyTriangle.Key;
                        currentKeyTriangle = currentMelody.triangles[4];
                        

                    }
                    else if (currentKeyTriangle.Key == currentMelody.triangles[4].Key)
                    {
                        BottomLeftTri.SetActive(true);
                        BottomLeftTri.GetComponent<SpriteRenderer>().color = currentKeyTriangle.Key;
                      
                    }
                }
            }
        }


        //WON STATE
        if(player == PlayerState.won)
        {

        }


        //LOST STATE
        if(player == PlayerState.lost)
        {

        }

    }


    public static Melody GetRandomMelody()
    {

        int randomIndex = Random.Range(0, allMelodies.Count);
        return allMelodies[randomIndex];

    }

}
