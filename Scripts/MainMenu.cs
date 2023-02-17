using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu: MonoBehaviour
{
    
    // Start is called before the first frame update
   

    public void PlayM()
    {
        SceneManager.LoadScene("Play");
    }
  
    public void AvoidanceM()
    {
        SceneManager.LoadScene("Avoidance");
        
    }
    
    public void HomeG()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void Backb()
    {
        SceneManager.LoadScene("MainMenu");
    }

}