using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Flag : MonoBehaviour
{
    [SerializeField] private string sceneToLoad;

    private Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>(); 
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        var player = other.GetComponent<Player>();          
                                                            
        if (player == null)                                 
            return;

        anim.SetTrigger("Raise"); 

        StartCoroutine(LoadLevel()); 
    }

    private IEnumerator LoadLevel()
    {
        PlayerPrefs.SetInt(sceneToLoad + "Unlocked", 1); 
        yield return new WaitForSeconds(3f); 
        SceneManager.LoadScene(sceneToLoad);  
    }
}
