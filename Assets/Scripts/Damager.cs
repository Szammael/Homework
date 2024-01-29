using UnityEngine;

public class Damager : MonoBehaviour
{
    [SerializeField] int damage;
    void OnTriggerEnter2D(Collider2D collision)
    {
        
        GameObject go = collision.gameObject;
        Damageable damageable = go.GetComponent<Damageable>();
        if (damageable != null)
        {
            damageable.Damage(damage);
        }

    }
}
