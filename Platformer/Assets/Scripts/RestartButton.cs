using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class RestartButton : MonoBehaviour
{
    //reference video: https://www.youtube.com/watch?v=TVSLCZWYL_E 
    
    public void RestartGame(){
        //SceneManager.LoadScene(SceneManager.GetActiveScene().BuildIndex());
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex);

    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


}
