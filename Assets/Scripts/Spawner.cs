using UnityEngine;

public class Spawner : MonoBehaviour
{
    int spawn_1 = 1;
    int spawn_2 = 2;
    int spawn_3 = 3;
    GameManager gameManager;

    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        InvokeRepeating("SpawnLvl1", 0.1f, 3);
        InvokeRepeating("SpawnLvl2", 120, 5);
        InvokeRepeating("SpawnLvl3", 420, 20);

    }

    void SpawnLvl1()
    {
        gameManager.Spawn(spawn_1);
    }
    void SpawnLvl2() 
    {
        gameManager.Spawn(spawn_2);
    }
    void SpawnLvl3() 
    {
        gameManager.Spawn(spawn_3);
    }

}
