using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PentagonController : MonoBehaviour
{
    public SpriteRenderer pentagon;
    public Sprite image;
    public KeyCode key;
    public GameController gameController;
    public static GameObject currentCollisionObject = null;

    public bool canPickUp = false;

    public AudioClip[] tones;
    private void Start()
    {
        gameController = GetComponent<GameController>(); 
    }


    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(key))
        {
            pentagon.color = new Color (121/255f, 43/255f, 128/255f, 1);
           
        }
        
        if(Input.GetKeyUp(key)){
            pentagon.color = new Color (204/255f, 147/255f, 209/255f, 1);
        }
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag=="Triangle"){
            currentCollisionObject = other.gameObject;
            canPickUp = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if(other.tag=="Triangle"){
            currentCollisionObject = null;
            canPickUp = false;
        }
    }
}
