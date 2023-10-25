using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject targetParent;
    public Text wintext;

    void Start()
    {
        wintext.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        CheckWin();
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("Main Menu", LoadSceneMode.Single);
        }
    }

    void CheckWin()
    {
        if (targetParent.transform.childCount <= 0)
        {
            wintext.enabled = true;
        }
        
    }

}
