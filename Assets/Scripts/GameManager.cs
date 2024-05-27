using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject hazardPrefab;
    
    public int maxHazardsNumber = 3;
    
    public TextMeshPro scoreText;

    public GameObject player;

    public int maxScore;
    
    private float timer;
    
    private int score;

    [SerializeField]
    private GameObject flag;
    
    void Start()
    {
        flag.SetActive(false);
        StartCoroutine(SpawnHazards());
    }

    private IEnumerator SpawnHazards()
    {
        var hazardsNumber = Random.Range(1, maxHazardsNumber);

        for (int i = 0; i < hazardsNumber; i++)
        {
            var x = Random.Range(-7, 7);
            var hazard = Instantiate(hazardPrefab, new Vector3(x, 11, player.transform.position.z + 5), Quaternion.identity);
            hazard.GetComponent<Rigidbody>().drag = 0;
        }

        yield return new WaitForSeconds(Random.Range(0.5f, 2f));

        yield return SpawnHazards();
    }

    public void GameOver()
    {
        SceneManager.LoadScene("GameOver");
    }

    public void IncrementScore()
    {
        score++;
        scoreText.text = "Score: " + score;

        if (score >= maxScore)
        {
            flag.SetActive(true);
        }
    }

}
