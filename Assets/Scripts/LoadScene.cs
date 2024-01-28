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


    void Start()
    {
        animator = GetComponent<Animator>();
        animator.SetTrigger("Blink");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKey && !hasTriggered) {
            SceneManager.LoadScene(sceneToLoad); 
            hasTriggered = true; 
        }
    }

}
