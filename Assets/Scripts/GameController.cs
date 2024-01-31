using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
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
        continueNextLevel,
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

    public TMP_Text levelText; 

    public GameObject trianglePrefab;
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

    public Sprite[] possibleBackgrounds;

    public GameObject currentBackground; 

    public static int levelCounter = 1;

    public static bool isNextLevel = false; 

    

   



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

        levelText.text = "Level " + levelCounter;

        //START STATE
        if (player == PlayerState.start)
        {

            Debug.Log(levelCounter + "level counter");
            currentMelody = GetRandomMelody();
            int randomBackground = Random.Range(0, possibleBackgrounds.Length);
            currentBackground.GetComponent<SpriteRenderer>().sprite = possibleBackgrounds[randomBackground]; 
            player = PlayerState.cutscene1;

        }

        if(player == PlayerState.cutscene1){
            playerPentagon.SetActive(false);
            tutorial.SetActive(true);
          

            for (int i=0;i<tutTriangles.Length;i++){
                tutTriangles[i].GetComponent<SpriteRenderer>().color = melodyColors[currentMelody[i]];
                
            }

            StartCoroutine(colorTutorial(tutTriangles));
            player = PlayerState.cutscene2;
  
        }
        if(player == PlayerState.cutscene3){

            if (isNextLevel && levelCounter > 1)
            {

                triangle.moveSpeed += 2.5f;
                isNextLevel = false;
            }

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
           

  
            if (Input.GetKeyDown(KeyCode.Space)){
                
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
                if(levelCounter >= 3)
                {
                    player=PlayerState.won;
                } else {
                    levelCounter++;
                    isNextLevel = true;
                    player = PlayerState.continueNextLevel;
                }
            } 
        }


        //CONTINUE TO NEXT LEVEL 
        if(player == PlayerState.continueNextLevel)
        {
            player = PlayerState.start;
            Debug.Log(levelCounter + "level counter"); 
            SceneManager.LoadScene("Continue Scene");   
        }

        //WON STATE
        if(player == PlayerState.won)
        {
            levelCounter = 1;
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
        
        List<int> melody = new List<int>();
        for(int i=0;i<5;i++){
            int randomNote = Random.Range(0,5);
            melody.Add(randomNote);
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
            levelCounter = 1;
        }
    }

}
