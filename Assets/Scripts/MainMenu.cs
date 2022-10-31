using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private GameObject scrollView;

    public void NewGame(string sceneToLoad)
    {
        PlayerPrefs.DeleteAll();
        SceneManager.LoadScene(sceneToLoad); 
    }

    public void LoadGame()
    {
        scrollView.SetActive(true);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
