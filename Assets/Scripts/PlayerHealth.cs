using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    private int currentHealth;

    public string enemyTag = "Enemy";  // Tag wrogów
    public int damageAmount = 50;      // Ilość obrażeń zadawanych graczowi
    public float damageDistance = 50f; // Odległość, w której wróg zadaje obrażenia
    public float damageInterval = 2f; // Czas między kolejnymi obrażeniami

    private float nextDamageTime = 0f; // Kiedy gracz może ponownie otrzymać obrażenia

    void Start()
    {
        currentHealth = maxHealth;
    }

    void Update()
    {
        // Znajdź wszystkie obiekty z tagiem "Enemy"
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);

        foreach (GameObject enemy in enemies)
        {
            float distance = Vector3.Distance(transform.position, enemy.transform.position);

            // Sprawdź, czy wróg jest w zasięgu obrażeń
            if (distance <= damageDistance && Time.time >= nextDamageTime)
            {
                ApplyDamage(damageAmount);
                nextDamageTime = Time.time + damageInterval; // Ustaw czas do następnych obrażeń
                break; // Przerwij pętlę, jeśli jeden wróg zadał obrażenia
            }
        }
    }

    private void ApplyDamage(int amount)
    {
        currentHealth -= amount;
        Debug.Log("Gracz otrzymał obrażenia! Aktualne zdrowie: " + currentHealth);

        if (currentHealth <= 0)
        {
            currentHealth = 0;
            Debug.Log("Przegrałeś");
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    // Rysowanie zasięgu w edytorze
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red; // Kolor sfery
        Gizmos.DrawWireSphere(transform.position, damageDistance); // Rysowanie sfery w miejscu gracza
    }
}
