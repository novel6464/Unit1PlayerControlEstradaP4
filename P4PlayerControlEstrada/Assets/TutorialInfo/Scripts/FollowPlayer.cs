using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    
    public GameObject player;
    public Vector3 offset = new Vector3(0, 4, 2);
    // Update is called once per frame

    void LateUpdate()
    {
        transform.position = player.transform.position + offset;
        transform.rotation = player.transform.rotation;
    }
}
