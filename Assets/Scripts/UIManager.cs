using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{

    [SerializeField] private TextMeshProUGUI numberEnemies;
    [SerializeField] private TextMeshProUGUI defeatNumberEnemies;
    [SerializeField] private GameObject pausePanel;
    [SerializeField] private GameObject gameOverPanel;
    private SpawnManager spawnManager;



    // Start is called before the first frame update
    void Start()
    {

        pausePanel.SetActive(false);
        gameOverPanel.SetActive(false);

        spawnManager = FindAnyObjectByType<SpawnManager>();
        
    }

    // Update is called once per frame
    void Update()
    {

        numberEnemies.text = $"Enemies: {spawnManager.enemyCount}";
        defeatNumberEnemies.text = $"Defeat: {spawnManager.wave -1} enemies";
        
    }


    public void ShowPausePanel()
    {
        pausePanel.SetActive(true);
        Time.timeScale = 0;
    }
    public void HidePausePanel()
    {
        pausePanel.SetActive(false);
        Time.timeScale = 1;
    }


    public void ShowGameOverPanel()
    {
        gameOverPanel.SetActive(true);
        
    }
    public void HideGameOverPanel()
    {
        gameOverPanel.SetActive(false);
        
    }





}
