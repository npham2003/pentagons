using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using static MelodyModel;
using static PentagonController;
using static Spawner;


public class GameController : MonoBehaviour
{

    public enum PlayerState
    {
        none,
        start,
        cutscene1,
        cutscene2,
        cutscene3,
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
    public List<int> currentMelody;
    public Spawner triangle;

    public GameObject tutorial;

    public GameObject[] tutTriangles;

    public int lives = 3;

    public GameObject[] lifeIcons;

    public GameObject playerPentagon;
    public int currentKeyTriangle;

    public AudioSource audioSource;
    
    public GameObject[] playerTriangles;

    public int iter;


    private void OnEnable()
    {
        player = PlayerState.none; 
    }

    // Start is called before the first frame update
    void Start()
    {
        player = PlayerState.start;
        audioSource = gameObject.GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        
        //START STATE
        if(player == PlayerState.start)
        {
            currentMelody = GetRandomMelody();
            player = PlayerState.cutscene1;

        }

        if(player == PlayerState.cutscene1){
            playerPentagon.SetActive(false);
            tutorial.SetActive(true);
            
            for(int i=0;i<tutTriangles.Length;i++){
                tutTriangles[i].GetComponent<SpriteRenderer>().color = melodyColors[currentMelody[i]];
                
            }

            StartCoroutine(colorTutorial(tutTriangles));
            player = PlayerState.cutscene2;
  
        }
        if(player == PlayerState.cutscene3){
           
            triangle.Spawn();
            playerPentagon.SetActive(true);
            tutorial.SetActive(false);
            player = PlayerState.playing;
            currentKeyTriangle = currentMelody[0];
            iter=0;
        }
        //PLAYING STATE
        if(player == PlayerState.playing)
        {
            //if triangle enters pentagon and player presses space check if the triangle is the correct one and activate the correct triangle on the pentagon
            if(Input.GetKeyDown(KeyCode.Space)){
                
                if(pentagonController.canPickUp)
                {
                    Debug.Log("hit tri");
                    
                    if (randomTriangle.Key == melodyColors[currentKeyTriangle])
                    {
                        if (currentKeyTriangle == currentMelody[iter])
                        {
                            
                            playerTriangles[iter].SetActive(true);
                            playerTriangles[iter].GetComponent<SpriteRenderer>().color = melodyColors[currentKeyTriangle];
                            iter+=1;
                            currentKeyTriangle = currentMelody[iter];
                        
                        }
                        
                        // if (currentKeyTriangle == currentMelody[0])
                        // {
                        //     topLeftTri.SetActive(true);
                        //     topLeftTri.GetComponent<SpriteRenderer>().color = melodyColors[currentKeyTriangle];
                        //     currentKeyTriangle = currentMelody[1];
                        
                        // }
                        // else if (currentKeyTriangle == currentMelody[1])
                        // {
                        //     topCenterTri.SetActive(true);
                        //     topCenterTri.GetComponent<SpriteRenderer>().color = melodyColors[currentKeyTriangle];
                        //     currentKeyTriangle = currentMelody[2];
                        
                        // }
                        // else if (currentKeyTriangle == currentMelody[2])
                        // {
                        //     topRightTri.SetActive(true);
                        //     topRightTri.GetComponent<SpriteRenderer>().color = melodyColors[currentKeyTriangle];
                        //     currentKeyTriangle = currentMelody[3];
                            

                        // }
                        // else if (currentKeyTriangle == currentMelody[3])
                        // {
                        //     BottomRightTri.SetActive(true);
                        //     BottomRightTri.GetComponent<SpriteRenderer>().color = melodyColors[currentKeyTriangle];
                        //     currentKeyTriangle = currentMelody[4];
                            

                        // }
                        // else if (currentKeyTriangle == currentMelody[4])
                        // {
                        //     BottomLeftTri.SetActive(true);
                        //     BottomLeftTri.GetComponent<SpriteRenderer>().color = melodyColors[currentKeyTriangle];
                        //     player = PlayerState.won;
                        
                        // }
                    }else{
                        LoseLife();
                    }
                    
                }else{
                    LoseLife();
                }
                Destroy(triangle.newTriangle);
                triangle.Spawn();
            }
            if(iter==5){
                player=PlayerState.won;
            }
        }


        //WON STATE
        if(player == PlayerState.won)
        {
            SceneManager.LoadScene("Win Scene");
        }


        //LOST STATE
        if(player == PlayerState.lost)
        {
            SceneManager.LoadScene("Lose Scene");
        }

    }

    public void TriangleDestroyed(){
        if (randomTriangle.Key == melodyColors[currentKeyTriangle]){
            LoseLife();
        }
    }
    public static List<int> GetRandomMelody()
    {

        int randomIndex = Random.Range(0, allMelodies.Count);
        
        List<int> melody = new List<int>();
        for(int i=0;i<5;i++){
            int randomNote = Random.Range(0,5);
            melody.Add(randomNote);
            Debug.Log(randomNote);
        }
        

        return melody;
        

    }

    IEnumerator colorTutorial(GameObject[] triangles){
        for(int i=0;i<triangles.Length;i++){
            Color oldColor = triangles[i].GetComponent<SpriteRenderer>().color;
            triangles[i].GetComponent<SpriteRenderer>().color = new Color(oldColor.r,oldColor.g,oldColor.b,0.5f);
            audioSource.clip=playerPentagon.GetComponent<PentagonController>().tones[currentMelody[i]];
            audioSource.Play();
            yield return new WaitForSeconds(1);
            triangles[i].GetComponent<SpriteRenderer>().color = new Color(oldColor.r,oldColor.g,oldColor.b,1);
        }
        player=PlayerState.cutscene3;
    }
    private void LoseLife(){
        lives-=1;
        lifeIcons[lives].SetActive(false);
        if(lives==0){
            player = PlayerState.lost;
        }
    }

}
