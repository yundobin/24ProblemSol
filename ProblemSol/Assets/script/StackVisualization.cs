using UnityEngine;
using UnityEditor;
using Datastructure; // Datastructure 네임스페이스 사용

public class StackVisualization : MonoBehaviour
{
    public GameObject cubePrefab; // 큐브 프리팹
    private Stack<int> stack; // 스택
    private GameObject[] cubes; // 생성된 큐브 배열
    private int cubeHeightOffset = 1; // 큐브의 높이 오프셋
    private GameObject container; // 큐브를 담을 컨테이너 GameObject

    void Start()
    {
        stack = new Stack<int>(); // 스택 초기화
        cubes = new GameObject[0]; // 큐브 배열 초기화

        // Container GameObject 생성
        container = new GameObject("Container");
    }

    void Update()
    {
        // 좌클릭을 하면 큐브 생성
        if (Input.GetMouseButtonDown(0))
        {
            int newData = Random.Range(1, 10); // 임의의 데이터 생성 (여기서는 랜덤 값 사용)
            CreateCube(newData); // 큐브 생성
            stack.Push(newData); // 스택에 데이터 추가
        }
        // 우클릭을 하면 큐브 제거
        else if (Input.GetMouseButtonDown(1))
        {
            if (!stack.IsEmpty())
            {
                int removedData = stack.Pop(); // 스택에서 데이터 제거
                DestroyCube(); // 큐브 제거
            }
            else
            {
                Debug.Log("스택이 비어 있습니다.");
            }
        }
    }

    // 큐브 생성 메서드
    void CreateCube(int data)
    {
        GameObject cube = Instantiate(cubePrefab, Vector3.zero, Quaternion.identity, container.transform); // 컨테이너를 부모로 설정하여 큐브 생성
        cube.transform.localPosition = new Vector3(0f, cubes.Length * cubeHeightOffset, 0f); // 현재 큐브의 수에 따라 위치 계산
        cube.name = "Cube " + data.ToString(); // 큐브 이름 설정
        ArrayUtility.Add(ref cubes, cube); // 큐브 배열에 추가
    }

    // 큐브 제거 메서드
    void DestroyCube()
    {
        if (cubes.Length > 0)
        {
            GameObject cubeToRemove = cubes[cubes.Length - 1]; // 가장 위에 있는 큐브 선택
            Destroy(cubeToRemove); // 큐브 제거
            ArrayUtility.RemoveAt(ref cubes, cubes.Length - 1); // 큐브 배열에서 제거
        }
    }
}
