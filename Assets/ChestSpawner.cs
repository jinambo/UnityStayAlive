using System.Collections;
using UnityEngine;

public class ChestSpawner : MonoBehaviour {
    public GameObject chestPrefab;
    public float spawnRadius = 2.5f;
    public float spawnInterval = 15f;

    private void Start() {
        StartCoroutine(SpawnChests());
    }

    IEnumerator SpawnChests() {
        while (true) {
            Vector2 spawnPosition = (Vector2)transform.position + Random.insideUnitCircle * spawnRadius;
            print("Spawn position: " + spawnPosition);

            GameObject newChestPrefab = chestPrefab;

            // Instantiate the enemy prefab and get a reference to the Enemy component
            GameObject newChestGameObject = Instantiate(newChestPrefab, spawnPosition, Quaternion.identity);
            Chest newChest = newChestGameObject.GetComponent<Chest>();

            // Set the properties of the new chest

            yield return new WaitForSeconds(spawnInterval);
        }
    }
}
