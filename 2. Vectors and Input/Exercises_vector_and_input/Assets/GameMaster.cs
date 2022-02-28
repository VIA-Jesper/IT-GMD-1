using System;
using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;

public class GameMaster : MonoBehaviour
{
    public int missedMoles = 0;
    [SerializeField] private Transform Ground;
    [SerializeField] private GameObject molePrefab;
    public int Score;
    private float spawnTimer;
    [SerializeField] private float spawnInterval;
    [SerializeField] private TMP_Text scoreText;
    [SerializeField] private TMP_Text spawnTimeText;
    [SerializeField] private float decrementvalue = 0.1f;
    [SerializeField] private TMP_Text missedText;
    [SerializeField] private int maxMissedMoles = 10;
    [SerializeField] private TMP_Text losstext;
    private void Update()
    {
        spawnTimer -= Time.deltaTime;
        spawnTimeText.text = "Next Spawn:" + spawnTimer.ToString("F1");
        if (spawnTimer <= 0f)
        {
            spawnTimer = spawnInterval;
            SpawnMole();
        }

        scoreText.text = "Score: " + Score;
        missedText.text = "Missed moles:" + missedMoles + "/ " + maxMissedMoles;

        if (missedMoles >= maxMissedMoles)
        {
            losstext.enabled = true;
            spawnInterval = 9999999;
        }
    }


    private void SpawnMole()
    {
        var point = Random.insideUnitCircle * 4f;
        Instantiate(molePrefab, new Vector3(point.x, 0f, point.y), Quaternion.identity);
    }

    public void DecrementTimer()
    {
        if (spawnInterval >= 0.1f)
        {
            spawnInterval -= decrementvalue;
        }

    }
}
