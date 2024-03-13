using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    private PlayerControl playerControl;

    private UIManager uiManager;

    // Start is called before the first frame update
    void Start()
    {
        playerControl = FindAnyObjectByType<PlayerControl>();
        uiManager = FindAnyObjectByType<UIManager>();

        
    }

    // Update is called once per frame
    void Update()
    {

        //SceneManager.LoadSceneAsync(0);

    }

    public void ContinuePause()
    {
        if (!playerControl.paused)
        {
            uiManager.ShowPausePanel();
            playerControl.paused = true;

        }
        else if (playerControl.paused == true)
        {
            uiManager.HidePausePanel();
            playerControl.paused = false;

        }
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void MainMenu()
    {
        SceneManager.LoadSceneAsync(0);
    }



}
