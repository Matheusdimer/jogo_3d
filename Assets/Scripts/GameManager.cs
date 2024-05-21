using System.Collections;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject hazardPrefab;
    public int maxHazardsNumber = 3;
    public TextMeshPro scoreText;
    
    private float timer;
    
    private static int score;
    private static bool gameOver;
    
    void Start()
    {
        StartCoroutine(SpawnHazards());
    }

    void Update()
    {
        if (gameOver) return;
        scoreText.text = score.ToString();
    }

    private IEnumerator SpawnHazards()
    {
        var hazardsNumber = Random.Range(1, maxHazardsNumber);

        for (int i = 0; i < hazardsNumber; i++)
        {
            var x = Random.Range(-7, 7);
            var drag = Random.Range(0f, 3f);
            var hazard = Instantiate(hazardPrefab, new Vector3(x, 11, 0), Quaternion.identity);
            hazard.GetComponent<Rigidbody>().drag = drag;
        }

        yield return new WaitForSeconds(Random.Range(0.5f, 1.5f));

        yield return SpawnHazards();
    }

    public static void GameOver()
    {
        gameOver = true;
    }

    public static void IncrementScore()
    {
        score++;
    }
}
