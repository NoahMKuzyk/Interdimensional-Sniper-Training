using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMenuManager : MonoBehaviour
{
    // Start is called before the first frame update
    private void Start()
    {
        StartCoroutine(cursorEnable());
       
    }

    IEnumerator cursorEnable()
    {
        yield return new WaitForSeconds(1);
        Cursor.visible = true;
    }
    public void LoadLevel1()
    {
        Cursor.visible = false;
        SceneManager.LoadScene("Level 1", LoadSceneMode.Single);
    }
    public void LoadLevel2()
    {
        Cursor.visible = false;
        SceneManager.LoadScene("Level 2", LoadSceneMode.Single);
    }
    public void LoadLevel3()
    {
        Cursor.visible = false;
        SceneManager.LoadScene("Level 3", LoadSceneMode.Single);
    }
    public void LoadLevel4()
    {
        Cursor.visible = false;
        SceneManager.LoadScene("Level 4", LoadSceneMode.Single);
    }
    public void LoadLevel5()
    {
        Cursor.visible = false;
        SceneManager.LoadScene("Level 5", LoadSceneMode.Single);
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    void Update()
    {
       
    }
}
