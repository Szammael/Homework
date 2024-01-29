using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] float maxHP = 10;
        GameManager gameManager;
    [SerializeField] int spawnInt;
    [SerializeField] float speed;
    [SerializeField] GameObject player;
    [SerializeField] int expReward = 1;
    float currentHP;
    

    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        player = gameManager.Player();
        Player.enemyList.Add (this);
        currentHP = maxHP;
    }

    void OnDestroy()
    {
        Player.enemyList.Remove (this);
    }

    void Update () 
    { 
        Vector2 position = transform.position;
        transform.position = Vector2.MoveTowards(position, player.transform.position, speed * Time.deltaTime);
        if(player.transform.position.x - position.x>0) 
        {
            Vector2 scale = transform.localScale;
            scale.x = -1;
            transform.localScale = scale;
        }
        else 
        {
            Vector2 scale = transform.localScale;
            scale.x = 1;
            transform.localScale = scale;
        }

        if (currentHP <= 0)
        {
            Player player1 = player.GetComponent<Player>();
            player1.Reward(expReward);
            gameManager.Spawn(spawnInt);
            Destroy(this.gameObject);
        }
    }

    public void playerHit(float damage)
    {
        currentHP -= damage;
        
    }
}
