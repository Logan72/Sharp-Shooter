using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] int initialHealth;
    int currentHealth;

    void Awake()
    {
        currentHealth = initialHealth;
    }

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
        if (currentHealth <= 0) Destroy(gameObject);
    }
}
