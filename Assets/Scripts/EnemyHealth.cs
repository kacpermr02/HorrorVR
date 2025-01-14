using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [Header("Ustawienia zdrowia")]
    [Tooltip("Początkowa ilość zdrowia wroga")]
    public int maxHealth = 100;

    [Tooltip("Tag obiektu, z którym kolizja zadaje obrażenia")]
    public string damagingTag = "Weapon";

    [Tooltip("Ilość obrażeń zadawanych przy kolizji z obiektem o podanym tagu")]
    public int damageAmount = 50;

    private int currentHealth;

    private void Start()
    {
        currentHealth = maxHealth;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag(damagingTag))
        {
            TakeDamage(damageAmount);
        }
    }

    private void TakeDamage(int amount)
    {
        currentHealth -= amount;
        Debug.Log($"Wróg otrzymał {amount} obrażeń. Pozostało zdrowia: {currentHealth}");

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Debug.Log("Wróg został zniszczony.");
        Destroy(gameObject);
    }
}
