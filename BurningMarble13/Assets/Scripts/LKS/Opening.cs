using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Opening : MonoBehaviour
{
    public GameObject startScreenUI;
    //public GameObject mainMenuUI;

    // Start is called before the first frame update
    void Start()
    {
        startScreenUI.SetActive(true); //���߿� true�� �ٲٱ�
        //mainMenuUI.SetActive(false); //���߿� false�� �ٲٱ�
    }

    
    public void StartGame()
    {
        SceneManager.LoadScene("MainMenu");
        //startScreenUI.SetActive(false);
        //mainMenuUI.SetActive(true);
    }
}

