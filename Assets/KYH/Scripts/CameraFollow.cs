using UnityEngine;

public class CameraFollowYOnly : MonoBehaviour
{
    public Transform player; // �÷��̾��� Transform
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

            // ���� ī�޶��� ��ġ�� ������
            Vector3 currentPosition = transform.position;

            currentPosition.x = targetX;

            // ī�޶��� ��ġ�� ������Ʈ
            transform.position = currentPosition;
        }
    }
}
