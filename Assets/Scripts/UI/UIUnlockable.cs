using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIUnlockable : MonoBehaviour
{
    private void OnEnable()
    {
        var startLevelButton = GetComponent<UISceneLoader>();
        string key = startLevelButton.SceneToLoad + "Unlocked"; 
        int locked = PlayerPrefs.GetInt(key, 0);

        if (locked == 0)
            gameObject.SetActive(false);
    }
}
