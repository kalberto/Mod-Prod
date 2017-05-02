using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScreenOnClick : MonoBehaviour {	
    public void LoadByIndex(int p_sceneIndex)
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(p_sceneIndex);
    }    
}
