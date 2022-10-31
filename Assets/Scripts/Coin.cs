using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public static int Coins; 

    [SerializeField] private List<AudioClip> clips;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Coins++;                                 
            Debug.Log($"ho preso {Coins} coins");    
            GetComponent<SpriteRenderer>().enabled = false;
            GetComponent<Collider2D>().enabled = false;

            ScoreSystem.AddPoints(10);
            
            int randomIndex = UnityEngine.Random.Range(0, clips.Count);
            AudioClip clip = clips[randomIndex];
            if(clips != null)
            {
                GetComponent<AudioSource>().PlayOneShot(clip);
            }
            else
            {
                GetComponent<AudioSource>().Play();
            }
        }
    }
}
