using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PentagonController : MonoBehaviour
{
    private SpriteRenderer pentagon;
    public Sprite image;
    public KeyCode key;
    // Start is called before the first frame update
    void Start()
    {
        pentagon=GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(key))
        {
            pentagon.color = new Color (1,0,0,1);
        }
        
        if(Input.GetKeyUp(key)){
            pentagon.color = new Color (0,1,0,1);
        }
    }
}
