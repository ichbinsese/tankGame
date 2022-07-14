using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathWindow : MonoBehaviour
{
    // Start is called before the first frame update
    public void Restart()
    {
        GetComponent<MainMenuWindow>().PlayClick();
        Time.timeScale = 1;
        StopAllCoroutines();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name ,LoadSceneMode.Single);
        
    }
    public void Surender()
    {
        GetComponent<MainMenuWindow>().PlayClick();
        Time.timeScale = 1;
        StopAllCoroutines();
        SceneManager.LoadScene(0);
       
    }

}
