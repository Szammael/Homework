using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] float innerCircleRadius = 10;
    [SerializeField] float outerCircleRadius = 20;
    [SerializeField] GameObject player;
    [SerializeField] GameObject spawn_1;
    [SerializeField] GameObject spawn_2;
    [SerializeField] GameObject spawn_3;
    [SerializeField] GameObject plane;
    [SerializeField] int size;
    Vector3 center;
    int playerLevel;
    Vector3 spawnPos;


    private void Start()
    {
        for (int i = -size; i <= size; i=i+10) 
        { 
        for(int j = -size; j <= size; j=j+10)
            {
                Vector3 pos = new Vector3(i, j, 3);
                GameObject newPlane = Instantiate(plane, pos, Quaternion.identity);
            }
        }
    }


    void Update()
    {
        center = player.transform.position;
        playerLevel = player.GetComponent<Player>().CurrentLevel();
        Vector3 spawnPoint = Vector3.one;
        while (Mathf.Abs(spawnPoint.magnitude) < innerCircleRadius)
        {
            spawnPoint = Random.insideUnitCircle * outerCircleRadius;
        }
        spawnPos = spawnPoint;
    }

   

    void OnDrawGizmos()
    {
        Gizmos.color = Color.white;
        Gizmos.DrawWireSphere(center, innerCircleRadius);
        Gizmos.color= Color.blue;
        Gizmos.DrawWireSphere (center, outerCircleRadius);  
    }

    public GameObject Player() 
    { 
        return player; 
    }
    
    public void Spawn(int gOInt)
    {

        /*float coX = Mathf.Round(Random.Range(1, 2.1f));
        if (coX == 2) { coX = -1; }
        float coY = Mathf.Round(Random.Range(1, 2.1f));
        if (coY == 2) { coY = -1; }
        float randomX = Random.Range(innerCircleRadius, Random.insideUnitCircle.x * outerCircleRadius);
        float randomY = Random.Range(innerCircleRadius, Random.insideUnitCircle.y * outerCircleRadius);
        */

        if (gOInt == 1)
        {            
            GameObject newEnemy = Instantiate(spawn_1, center + spawnPos, Quaternion.identity);
        }

        if (gOInt == 2)
        {
            GameObject newEnemy = Instantiate(spawn_2, center + spawnPos, Quaternion.identity);
        }

        if (gOInt == 3)
        {
            GameObject newEnemy = Instantiate(spawn_3, center + spawnPos, Quaternion.identity);
        }
       
    }       
    
}
