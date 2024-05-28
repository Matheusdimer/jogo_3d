using System.Collections;
using UnityEngine;

public class Congratulations : MonoBehaviour
{
    public GameObject hazardPrefab;
    
    void Start()
    {
        StartCoroutine(SpawnBombs());
    }
    
    private IEnumerator SpawnBombs()
    {
        var hazardsNumber = 3;

        for (int i = 0; i < hazardsNumber; i++)
        {
            var hazard = Instantiate(hazardPrefab, new Vector3(0, -5, 0), Quaternion.identity);
            hazard.GetComponent<Rigidbody>().AddForce(new Vector3(Random.Range(-5, 5), 10, 0), ForceMode.Impulse);
            Destroy(hazard, 10);
        }

        yield return new WaitForSeconds(Random.Range(0.5f, 2f));

        yield return SpawnBombs();
    }
}
