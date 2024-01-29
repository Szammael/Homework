using UnityEngine;

public class FollowerCam : MonoBehaviour
{
    [SerializeField] Transform player;
    void Update()
    {
        Vector3 selfPos = transform.position;
        selfPos.z = -10;
        transform.position = Vector3.MoveTowards(selfPos, player.position, 5f);
        
    }
}
