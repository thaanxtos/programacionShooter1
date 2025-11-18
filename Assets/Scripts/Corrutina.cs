using System.CodeDom.Compiler;
using System.Collections;
using UnityEngine;

public class Corrutinas : MonoBehaviour
{
    GameObject enemyPrefab;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(CorrutinaGenerateEnemy());
        InvokeRepeating(nameof(GenerateEnemy), 0.0f, 2.0f);
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void GenerateEnemy()
    {
        GameObject enemy = Instantiate(enemyPrefab);
    }
    
    IEnumerable CorrutinaGenerateEnemy()
    {
        yield return new WaitForSeconds(Random.Range(2, 8));
        GenerateEnemy();
        StartCoroutine(GenerateEnemy());
    }
}
