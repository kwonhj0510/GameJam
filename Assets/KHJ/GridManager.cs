using UnityEngine;

public class GridManager : MonoBehaviour
{
    [SerializeField] private GameObject carPrefab; // �ڵ��� ������
    [SerializeField] private Transform gridPanel; // GridLayoutGroup�� ���� �г�

    [SerializeField] private int gridWidth = 6; // �׸����� �ʺ� (�� ��)
    [SerializeField] private int gridHeight = 6; // �׸����� ���� (�� ��)

    private void Start()
    {
        InitializeGrid();
    }

    private void InitializeGrid()
    {
        // ������ ������ ��� �ڵ����� �����մϴ�.
        foreach (Transform child in gridPanel)
        {
            Destroy(child.gameObject);
        }

        // �׸��忡 �ڵ����� ��ġ�մϴ�.
        for (int y = 0; y < gridHeight; y++)
        {
            for (int x = 0; x < gridWidth; x++)
            {
                // �ڵ��� �������� �����մϴ�.
                GameObject car = Instantiate(carPrefab, gridPanel);
                RectTransform rectTransform = car.GetComponent<RectTransform>();

                // �ڵ����� ��ġ�� �����մϴ�.
                rectTransform.anchoredPosition = new Vector2(x * (100 + 10), y * (100 + 10)); // Cell Size�� Spacing�� ����մϴ�.
            }
        }
    }
}


