using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class StartButton : MonoBehaviour
{
    //reference video: https://www.youtube.com/watch?v=TVSLCZWYL_E 
    
   public string scene;

    // Update is called once per frame
    public void StartGame()
    {
        SceneManager.LoadScene(scene);
    }


}
