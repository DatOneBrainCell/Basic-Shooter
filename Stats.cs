using UnityEngine;

public class Stats : MonoBehaviour
{
    [SerializeField] private int maxHealth;

    private int health;
    
    internal void Damage(int dmgAmt) {

        if (health <= 0) {
            Destroy(gameObject);
        }
        else {
            health -= Random.Range(dmgAmt - 7, dmgAmt + 5);
        }
        Debug.Log("It hurts");
    }

    internal void Heal(int healAmt) {

        if (health >= maxHealth) {
            health = maxHealth;
        }
        else {
            health += healAmt;
        }
    }
}
