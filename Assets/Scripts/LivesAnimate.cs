using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LivesAnimate : MonoBehaviour
{
    // Start is called before the first frame update

    public SpriteRenderer sprite;
    private int shade = 220;

    public bool up = false;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(up){
            shade += 1;
        }else{
            shade-=1;
        }

        if(shade<=170){
            up = true;
        }
        if(shade>=240){
            up = false;
        }
        sprite.color = new Color(shade/255f, shade/255f, shade/255f, 1f);
    }
}
