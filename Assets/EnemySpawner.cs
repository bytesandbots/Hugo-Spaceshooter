using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using TMPro;
using Unity.VisualScripting;

public class EnemySpawner : MonoBehaviour
{

    public GameObject enemyPrefab;
    public GameObject BossPrefab;
    int wave = 1;
    float spawnDistance = 12f;
    int EnemiesToSpawn = 3;
    public TMP_Text waveText;
    public TMP_Text enemiesLeft;
    float enemyRate = 5;
    float nextEnemy = 1;
    int currentEnemies;
    bool waveStarted;
    bool waiting;
    public int BossKilled;
   
    private void Start()
    {
        waveText.text = "Wave " + wave.ToString();
        enemiesLeft.text = "Enemies x " + currentEnemies.ToString();
    }
    // Update is called once per frame
    void Update()
    {
        if(BossKilled == 0)
        {
            SceneManager.LoadScene("you win");

        }
        if (waiting) { return; }
        if (currentEnemies <= EnemiesToSpawn && !waveStarted)
        {
            nextEnemy -= Time.deltaTime;

            if (nextEnemy <= 0)
            {
                nextEnemy = enemyRate;
                enemyRate *= 0.9f;
                if (enemyRate < 2)
                    enemyRate = 2;

                Vector3 offset = Random.onUnitSphere;

                offset.z = 0;

                offset = offset.normalized * spawnDistance;
                if(wave%10 == 0 && wave != 0){
                    Instantiate(BossPrefab, transform.position + offset, Quaternion.identity);
                    currentEnemies = EnemiesToSpawn;
                    waveStarted = true;
                    return;
                }
                Instantiate(enemyPrefab, transform.position + offset, Quaternion.identity);
                currentEnemies++;
                enemiesLeft.text = "Enemies x " + currentEnemies.ToString();
                if (currentEnemies == EnemiesToSpawn) {
                    waveStarted = true;
                }
            }
        }

        else {
            currentEnemies = GameObject.FindGameObjectsWithTag("Enemy").Length;
            enemiesLeft.text = "Enemies x " + currentEnemies.ToString();
            if (currentEnemies == 0) {
                StartCoroutine(waitForWave());
            }
        
        }
    }

    IEnumerator waitForWave() {
        waiting = true;
        yield return new WaitForSeconds(5);
        waiting = false;
        waveStarted = false;
        wave++;
        waveText.text = "Wave " + wave.ToString();
        EnemiesToSpawn += Random.Range(1, 4);
    }
}