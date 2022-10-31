using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CheckpointManager : MonoBehaviour
{
    private Checkpoint[] checkpoints; 

    public static CheckpointManager Instance { get; private set; } 

    void Awake()
    {
        Instance = this; 
    }

    void Start()
    {
        checkpoints = GetComponentsInChildren<Checkpoint>(); 
    }

    public Checkpoint GetLastCheckpoint() 
    {
        return checkpoints.LastOrDefault(t => t.Passed == true); 
    }
}
