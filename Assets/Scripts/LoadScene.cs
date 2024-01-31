using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class LoadScene : MonoBehaviour
{
    public string sceneToLoad;
    bool hasTriggered = false; 
    public GameObject playButtonText;
    public Animator animator;

    bool waiting = true;


    void Start()
    {
        animator = GetComponent<Animator>();
        animator.SetTrigger("Blink");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !hasTriggered && !waiting) {
            SceneManager.LoadScene(sceneToLoad); 
            hasTriggered = true; 
        }
        waiting=false;
    }

    

    IEnumerator wait(){
        yield return new WaitForSeconds(2f);
    }

}
