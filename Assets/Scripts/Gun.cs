using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{

    [SerializeField] float attackSPD = 2;
    [SerializeField] GameObject bullet;

    bool reloading = true;
    Vector3 playerPos;

    private void Start()
    {
        StartCoroutine(Reload());
    }

    IEnumerator Reload()
    {
        yield return new WaitForSeconds(attackSPD);
        reloading = false;

    }

    private void Update()
    {
        playerPos = transform.position ;


        if (reloading == false && Player.enemyList.Count > 0)
        {

            GameObject newBullet = Instantiate(bullet, playerPos, Quaternion.identity);
            reloading = true;
            StartCoroutine(Reload());
        }
    }

}
