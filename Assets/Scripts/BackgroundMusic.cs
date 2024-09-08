using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Ensures that the background music persists across scenes.
/// </summary>
public class BackgroundMusic : MonoBehaviour
{
    private static BackgroundMusic instance;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);  
        }
        else
        {
            Destroy(gameObject); 
        }
    }
}
