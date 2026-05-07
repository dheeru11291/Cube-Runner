using UnityEngine;

public class FollowPlay : MonoBehaviour
{
    public Transform player;
    public float OffSet;
    private void Update()
    {
       Vector3 cameraPos= transform.position;
        cameraPos.z=player.position.z+OffSet;
        transform.position = cameraPos;
    }

}
