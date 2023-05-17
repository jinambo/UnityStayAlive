using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {
    public GameObject enemyPrefab;
    public float spawnRadius = 3f;
    public float spawnInterval = 1f;

    private void Start() {
        StartCoroutine(SpawnEnemies());
    }

    IEnumerator SpawnEnemies() {
        while (true) {
            Vector2 spawnPosition = (Vector2)transform.position + Random.insideUnitCircle * spawnRadius;
            // print("Spawn position: " + spawnPosition);

            GameObject newEnemyPrefab = enemyPrefab;

            // Instantiate the enemy prefab and get a reference to the Enemy component
            GameObject newEnemyGameObject = Instantiate(newEnemyPrefab, spawnPosition, Quaternion.identity);
            
            float randomScale = Random.Range(0.5f, 1.5f);
            float randomDamage = Random.Range(5, 10) * randomScale;
            float randomHealth = Random.Range(20, 80) * randomScale;

            newEnemyGameObject.transform.localScale *= randomScale;
            Enemy newEnemy = newEnemyGameObject.GetComponent<Enemy>();

            // Set the properties of the new enemy
            newEnemy.isActive = true;
            newEnemy.enemyDamage = randomDamage;
            newEnemy.maxHealth = randomHealth;

            float dangerFactor = (newEnemy.maxHealth + newEnemy.enemyDamage) / 2f;

            Color color;

            if (dangerFactor <= 25) {
                color = new Color(0f, 1f, 0f, 0.85f);
            } else if (dangerFactor > 25 && dangerFactor < 50) {
                color = new Color(0f, 0f, 1f, 0.85f);
            } else {
                color = new Color(1f, 0f, 0f, 0.85f);
            }

            Renderer enemyRenderer = newEnemyGameObject.GetComponent<Renderer>();
            enemyRenderer.material.color = color;

            yield return new WaitForSeconds(spawnInterval);
        }
    }
}
