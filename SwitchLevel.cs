using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchLevel : MonoBehaviour
{
    public string levelToLoad;
    public void LoadTheLevel()
    {
        Application.LoadLevel(levelToLoad);
    }
}
