using UnityEngine;

public class CameraFollowYOnly : MonoBehaviour
{
    public Transform player; // 플레이어의 Transform
    public float minX = -2f;
    public float maxX = 48f;
    void LateUpdate()
    {
        if (player != null)
        {
            float targetX = player.position.x;
            if (targetX < minX)
            {
                targetX = minX;
            }
            if(targetX > maxX)
            {
                targetX = maxX;
            }

            // 현재 카메라의 위치를 가져옴
            Vector3 currentPosition = transform.position;

            currentPosition.x = targetX;

            // 카메라의 위치를 업데이트
            transform.position = currentPosition;
        }
    }
}
