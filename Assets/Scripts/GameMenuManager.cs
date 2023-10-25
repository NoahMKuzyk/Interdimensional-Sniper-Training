using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    // Start is called before the first frame update
    public void LoadLevel1()
    {
        SceneManager.LoadScene("Level 1", LoadSceneMode.Single);
    }
    public void LoadLevel2()
    {
        SceneManager.LoadScene("Level 2", LoadSceneMode.Single);
    }
    public void LoadLevel3()
    {
        SceneManager.LoadScene("Level 3", LoadSceneMode.Single);
    }
    public void LoadLevel4()
    {
        SceneManager.LoadScene("Level 4", LoadSceneMode.Single);
    }
    public void LoadLevel5()
    {
        SceneManager.LoadScene("Level 5", LoadSceneMode.Single);
    }
    public void ExitGame()
    {
        Application.Quit();
    }

}
