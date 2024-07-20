using UnityEngine;

public class GridManager : MonoBehaviour
{
    [SerializeField] private GameObject carPrefab; // 자동차 프리팹
    [SerializeField] private Transform gridPanel; // GridLayoutGroup을 가진 패널

    [SerializeField] private int gridWidth = 6; // 그리드의 너비 (열 수)
    [SerializeField] private int gridHeight = 6; // 그리드의 높이 (행 수)

    private void Start()
    {
        InitializeGrid();
    }

    private void InitializeGrid()
    {
        // 이전에 생성된 모든 자동차를 삭제합니다.
        foreach (Transform child in gridPanel)
        {
            Destroy(child.gameObject);
        }

        // 그리드에 자동차를 배치합니다.
        for (int y = 0; y < gridHeight; y++)
        {
            for (int x = 0; x < gridWidth; x++)
            {
                // 자동차 프리팹을 생성합니다.
                GameObject car = Instantiate(carPrefab, gridPanel);
                RectTransform rectTransform = car.GetComponent<RectTransform>();

                // 자동차의 위치를 설정합니다.
                rectTransform.anchoredPosition = new Vector2(x * (100 + 10), y * (100 + 10)); // Cell Size와 Spacing을 고려합니다.
            }
        }
    }
}


