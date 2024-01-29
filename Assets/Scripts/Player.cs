using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class Player : MonoBehaviour
{
    
    [SerializeField] float mvmtSpeed = 5;
    [SerializeField] MenuManager menuManager;
    int currentXP = 0;
    int nextLevel = 10;
    int currentLevel = 1;
    float levelMult = 1.2f;

    public static List<Enemy> enemyList = new();
    static Vector3 autoTarget;
    Vector3 playerPos;
    

    void Update()
    {
        float xInput = Input.GetAxisRaw("Horizontal");
        float yInput = Input.GetAxisRaw("Vertical");

                    
        playerPos.x += xInput * mvmtSpeed * Time.deltaTime;
        playerPos.y += yInput * mvmtSpeed * Time.deltaTime;
        transform.position = playerPos;
        AutoTargeting(playerPos);
    }

    public static Vector3 GiveMeTarget() 
    {
        Vector3 yourTarget = autoTarget;
        return yourTarget; 
    }

    public int CurrentLevel() 
    { 
        return currentLevel; 
    }
    

   void AutoTargeting(Vector3 position)
    {
        Vector3 target = Vector3.one * 100;
        foreach (Enemy enemy in enemyList)
        {
            
            Vector3 enemyPosition = enemy.transform.position;
            float targetDistance = position.magnitude - enemyPosition.magnitude;
            if (Mathf.Abs(targetDistance) < Mathf.Abs(target.magnitude))
                target = enemyPosition;
        }
        autoTarget = target;  

    }

    public void Reward(int exp)
    {
        currentXP += exp;
    }

    void FixedUpdate()
    {
        if (currentXP >= nextLevel)
        {
            int diff = currentXP - nextLevel;
            mvmtSpeed *= 1.1f;
            currentXP = 0 + diff;
            nextLevel = (int)Mathf.Ceil((float)nextLevel * levelMult);
            currentLevel++;
            levelMult *= levelMult;
        }

    }

}
