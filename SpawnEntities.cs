using System.Collections;
using UnityEngine;

public class SpawnEntities : MonoBehaviour
{
    [SerializeField] private GameObject[] gameObjectPrefabs;

    [SerializeField] private float spawnInterval;
    [SerializeField] private int enemyAmount;

    private BoxCollider spawnAreaCollider;

    private void Awake() {

        spawnAreaCollider = GetComponent<BoxCollider>();
    }

    private void Start() {

        StartCoroutine(nameof(SpawnEnemiesCoroutine));
    }

    private IEnumerator SpawnEnemiesCoroutine() {

        for (int i = 0; i < enemyAmount; i++) {
            yield return new WaitForSeconds(spawnInterval);
            SpawnEnemies();
        }
    }

    private void SpawnEnemies() {

        Bounds spawnAreaBounds = spawnAreaCollider.bounds;

        float randomBoundX = Random.Range(spawnAreaBounds.min.x, spawnAreaBounds.max.x);
        float randomBoundZ = Random.Range(spawnAreaBounds.min.z, spawnAreaBounds.max.z);

        Vector3 spawnAreaPosition = new Vector3(randomBoundX, transform.position.y, randomBoundZ);

        Debug.Log(randomBoundX + ", " + randomBoundZ);

        Instantiate(gameObjectPrefabs[0], spawnAreaPosition, Quaternion.identity);
    }
}
