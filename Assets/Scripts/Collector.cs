using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.Events;

public class Collector : MonoBehaviour
{
    [SerializeField] private List<Collectible> collectibles;  
    [SerializeField] private UnityEvent onComplete;  

    private TMP_Text gemRemainingText; 
    private int gemCollected; 

    void Start()
    {
        gemRemainingText = GetComponentInChildren<TMP_Text>(); 
        foreach(var collectible in collectibles)
        {
            collectible.OnPickUp += ItemPickUp;     
        }

        int gemRemaining = collectibles.Count - gemCollected; 
        gemRemainingText?.SetText(gemRemaining.ToString()); 
    }

    private void ItemPickUp() 
    {
        gemCollected++; 
        int gemRemaining = collectibles.Count - gemCollected; 
        gemRemainingText?.SetText(gemRemaining.ToString()); 

        if (gemRemaining > 0) 
            return; 

        onComplete.Invoke(); 
    }

    //void Update()
    //{
    //    //if (collectibles.Any(t => t.gameObject.activeSelf == true))
    //    //    return;

    //    foreach (var collectible in collectibles)
    //    {                                                           
    //        if (collectible.gameObject.activeSelf == true)       
    //            return;
    //    }

    //    //for (int i = 0; i < collectibles.Length; i++)
    //    //{
    //    //    if (collectibles[i].gameObject.activeSelf == true)
    //    //        return;
    //    //}

    //    gameObject.SetActive(false);
    //    Debug.Log("La porta è ora aperta");   
    //}

    void OnValidate() 
    {
        collectibles = collectibles.Distinct().ToList();  
    }

#if UNITY_EDITOR
    void OnDrawGizmos() 
    {
        foreach(var collectible in collectibles) 
        {
            if (Selection.activeGameObject == gameObject)  
                Gizmos.color = Color.blue; 
            else
                Gizmos.color = Color.grey; 

            Gizmos.DrawLine(transform.position, collectible.transform.position); 
        }
    }
#endif
}
