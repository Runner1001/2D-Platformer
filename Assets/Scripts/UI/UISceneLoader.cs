using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UISceneLoader : MonoBehaviour
{
    [SerializeField] private string sceneToLoad;

    public string SceneToLoad { get { return sceneToLoad; } }

    public void LoadScene()
    {
        SceneManager.LoadScene(sceneToLoad);
    }
}
