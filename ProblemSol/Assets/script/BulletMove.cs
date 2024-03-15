using UnityEngine;

public class BulletMove : MonoBehaviour
{
    public float bulletSpeed = 10f; // 총알 속도
    private GameObject cube; // 큐브 게임 오브젝트를 저장할 변수

    void Start()
    {
        // 큐브 게임 오브젝트 가져오기
        cube = GameObject.FindGameObjectWithTag("Cube");
        if (cube == null)
        {
            Debug.LogError("Cube GameObject not found!");
            return;
        }

        // 큐브 방향으로 총알을 발사하기 위해 큐브 방향으로의 벡터 계산
        Vector3 direction = (cube.transform.position - transform.position).normalized;
        // 발사 방향을 설정
        transform.forward = direction;
    }

    void Update()
    {
        // 총알을 현재 방향으로 이동
        transform.position += transform.forward * bulletSpeed * Time.deltaTime;
    }

    void OnTriggerEnter(Collider other)
    {
        // 충돌한 객체가 큐브인지 확인
        if (other.CompareTag("Cube"))
        {
            // 충돌한 큐브를 비활성화
            other.gameObject.SetActive(false);
            // 총알을 비활성화하여 재사용 가능한 상태로 변경
            gameObject.SetActive(false);
        }
    }
}
