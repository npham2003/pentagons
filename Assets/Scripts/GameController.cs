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
    public Melody currentMelody;
    public Spawner triangle;

    public GameObject tutorial;

    public GameObject[] tutTriangles;

    public int lives = 3;

    public GameObject[] lifeIcons;

    public GameObject playerPentagon;
    public int currentKeyTriangle;

    public AudioSource audioSource;
    
    


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
                tutTriangles[i].GetComponent<SpriteRenderer>().color = melodyColors[currentMelody.triangles[i]];
                
            }

            StartCoroutine(colorTutorial(tutTriangles));
            player = PlayerState.cutscene2;
  
        }
        if(player == PlayerState.cutscene3){
           
            triangle.Spawn();
            playerPentagon.SetActive(true);
            tutorial.SetActive(false);
            player = PlayerState.playing;
            currentKeyTriangle = currentMelody.triangles[0];
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
                        if (currentKeyTriangle == currentMelody.triangles[0])
                        {
                            topLeftTri.SetActive(true);
                            topLeftTri.GetComponent<SpriteRenderer>().color = melodyColors[currentKeyTriangle];
                            currentKeyTriangle = currentMelody.triangles[1];
                        
                        }
                        else if (currentKeyTriangle == currentMelody.triangles[1])
                        {
                            topCenterTri.SetActive(true);
                            topCenterTri.GetComponent<SpriteRenderer>().color = melodyColors[currentKeyTriangle];
                            currentKeyTriangle = currentMelody.triangles[2];
                        
                        }
                        else if (currentKeyTriangle == currentMelody.triangles[2])
                        {
                            topRightTri.SetActive(true);
                            topRightTri.GetComponent<SpriteRenderer>().color = melodyColors[currentKeyTriangle];
                            currentKeyTriangle = currentMelody.triangles[3];
                            

                        }
                        else if (currentKeyTriangle == currentMelody.triangles[3])
                        {
                            BottomRightTri.SetActive(true);
                            BottomRightTri.GetComponent<SpriteRenderer>().color = melodyColors[currentKeyTriangle];
                            currentKeyTriangle = currentMelody.triangles[4];
                            

                        }
                        else if (currentKeyTriangle == currentMelody.triangles[4])
                        {
                            BottomLeftTri.SetActive(true);
                            BottomLeftTri.GetComponent<SpriteRenderer>().color = melodyColors[currentKeyTriangle];
                            player = PlayerState.won;
                        
                        }
                    }else{
                        LoseLife();
                    }
                }else{
                    LoseLife();
                }
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


    public static Melody GetRandomMelody()
    {

        int randomIndex = Random.Range(0, allMelodies.Count);
       
        return allMelodies[randomIndex];

    }

    IEnumerator colorTutorial(GameObject[] triangles){
        for(int i=0;i<triangles.Length;i++){
            Color oldColor = triangles[i].GetComponent<SpriteRenderer>().color;
            triangles[i].GetComponent<SpriteRenderer>().color = new Color(oldColor.r,oldColor.g,oldColor.b,0.5f);
            audioSource.clip=playerPentagon.GetComponent<PentagonController>().tones[currentMelody.triangles[i]];
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
