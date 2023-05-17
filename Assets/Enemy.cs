using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    Animator animator;
    Rigidbody2D rb;
    public float enemyDamage = 5;
    public float detectionRadius = 2f;
    public float chaseSpeed = 0.7f;
    public bool isActive = false;

    private Transform playerTransform;

    GameOverScript gameOverScript;
    public GameObject timePrefab;
    public static string GOtime;
    public float Health {
        set {
            if (value < _health) animator.SetTrigger("hit");
            _health = value;
            if (_health <= 0) {
                animator.SetBool("isAlive", false);
                PointsScore.globalScore += (int)Math.Ceiling(1 * ((maxHealth + enemyDamage) / 2f) * 0.1);
            }
        }
        get { return _health; }
    }

    private float _health;
    public float maxHealth;

    private void Start() {
        animator = GetComponent<Animator>();
        animator.SetBool("isAlive", true);
        rb = GetComponent<Rigidbody2D>();

        // Find the player's transform
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;

        Health = maxHealth;
        print("enemy with health: " + maxHealth);
    }

    private void Update() {
        if (!isActive) return;

        // Calculate distance to the player
        float distanceToPlayer = Vector2.Distance(transform.position, playerTransform.position);

        if (distanceToPlayer <= detectionRadius) {
            // Calculate direction to the player
            Vector2 direction = playerTransform.position - transform.position;
            direction.Normalize();

            // Move towards the player
            rb.velocity = direction * chaseSpeed;
        } else {
            rb.velocity = Vector2.zero;
        }
    }

    public void TakeDamage(float damage, Vector2 knockback) {
        if (!isActive) return;

        Health -= damage;
        rb.AddForce(knockback);
        // print("Damage: " + damage);
        // print("Slime-man took damage: " + Health + " left.");
    }

    public void OnCollisionEnter2D(Collision2D collision) {
        if (!isActive) return;

        print("Enemy hit player (-" + enemyDamage + "HP)");
        // Deal with enemy damage
        if (collision.collider.tag == "Player") {
            PlayerController player = collision.collider.GetComponent<PlayerController>();
            if (player != null) {
                StartCoroutine(DelayedDamage(player));
            }
        }
    }

    IEnumerator DelayedDamage(PlayerController player) {
        yield return new WaitForSeconds(0.5f);
        player.TakeDamage(enemyDamage);
    }

    // Destroy enemy object if death animation ends
    public void RemoveEnemy() {
        if (!isActive) return;
        Destroy(gameObject);
    }
}
