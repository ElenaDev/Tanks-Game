using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    [Header ("Enemy Manager")]
    public GameObject tankEnemyPrefab;
    public Transform[] positions;
    public float time = 3;
    public int numTanksVictory;

    [Header("UI")]
    public TextMeshProUGUI textUI;
    public int numTankEnemy;
    public GameObject panelVictory;
    public GameObject panelGameOver;

    bool gameOver;

    void Start()
    {
        InvokeRepeating("CreateTankEnemy", time, time);
    }

    void Update()
    {
        
    }

    void CreateTankEnemy()
    {
        if (gameOver) return;

        int n = Random.Range(0, positions.Length);
        Instantiate(tankEnemyPrefab, positions[n].position, positions[n].rotation);
    }

    public void AddEnemyUI()
    {
        numTankEnemy++;
        textUI.text = "Tanks destroyed: " + numTankEnemy;

        if (numTankEnemy == numTanksVictory) Victory();
    }
    public void GameOver()
    {
        gameOver = true;
        panelGameOver.SetActive(true);
    }
    public void Victory()
    {
        panelVictory.SetActive(true);
    }
}
