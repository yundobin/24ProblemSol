using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    public GameObject planeObject; // 맵을 배치할 Plane 오브젝트
    public GameObject smallWallPrefab; // 작은 벽 프리팹
    public GameObject bigWallPrefab; // 큰 벽 프리팹
    public TextAsset csvFile; // CSV 파일을 직접 넣기 위한 변수

    void Start()
    {
        GenerateMap();
    }

    void GenerateMap()
    {
        Vector3 planeScale = planeObject.transform.localScale;
        string[] lines = csvFile.text.Split('\n');

        for (int y = 0; y < lines.Length; y++)
        {
            string line = lines[y];
            string[] values = line.Split(',');

            for (int x = 0; x < values.Length; x++)
            {
                if (int.TryParse(values[x], out int cellValue) && cellValue > 0)
                {
                    float cellPosX = (x - (values.Length / 2.0f) + 0.5f) * planeScale.x;
                    float cellPosZ = (y - (lines.Length / 2.0f) + 0.5f) * planeScale.z;
                    Vector3 position = new Vector3(cellPosX, 1, cellPosZ);
                    GameObject prefab = (cellValue == 1) ? smallWallPrefab : bigWallPrefab;

                    Instantiate(prefab, position, Quaternion.identity);
                }
            }
        }
        Debug.Log("Map has been generated.");
    }
}
