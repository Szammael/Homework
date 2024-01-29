using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] float attackDMG = 5;
    [SerializeField] float speed = 10;
    [SerializeField] float reach;
    Vector3 target = new();

    void Start()
    {
        target = Player.GiveMeTarget();
        Invoke("BulletSweep", reach);
    }

    void Update()
    {
        Vector3 selfPos = transform.position;
        transform.position = Vector3.MoveTowards(selfPos, target, speed * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject go=collision.gameObject; 
        Enemy enemy = go.GetComponent<Enemy>();
        if (enemy != null)
        {
            enemy.playerHit(attackDMG);
            Destroy(this.gameObject);
        }

    }

    void BulletSweep()
    {
        Destroy(this.gameObject);
    }


}
