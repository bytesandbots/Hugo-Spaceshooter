using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class buttonmaniger : MonoBehaviour
{

    public void startGameEASY()
    {
        SceneManager.LoadScene("GAME easy");
    }

    public void startGamemedium2()
    {
        SceneManager.LoadScene("GAME medium");
    }

    public void startGameHARD()
    {
        SceneManager.LoadScene("GAME HARD");
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
