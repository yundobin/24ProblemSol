using UnityEngine;
using Datastructure;

public class BulletMake : MonoBehaviour
{
    private Queue<GameObject> bulletQueue;
    public GameObject bulletPrefab; // 총알 프리팹

    void Start()
    {
        bulletQueue = new Queue<GameObject>();

        // 10개의 Bullet을 Queue에 넣기
        for (int i = 0; i < 10; i++)
        {
            GameObject bullet = Instantiate(bulletPrefab); // Bullet 프리팹을 인스턴스화
            bullet.SetActive(false); // 초기에는 비활성화 상태로 설정
            bulletQueue.Enqueue(bullet); // Queue에 추가
        }
    }

    void Update()
    {
        // 좌클릭했을 때 총알 발사
        if (Input.GetMouseButtonDown(0))
        {
            ShootBullet();
        }
    }

    public void ShootBullet()
    {
        if (bulletQueue.Count() > 0)
        {
            GameObject bullet = bulletQueue.Dequeue();
            bullet.SetActive(true);
            // Bullet 이동 등 추가적인 동작이 필요하다면 여기에 추가
        }
        else
        {
            Debug.Log("응 탄없어.");
        }
    }

    // 총알을 다시 사용 가능한 상태로 되돌리는 메서드
    public void ReturnBullet(GameObject bullet)
    {
        bullet.SetActive(false); // 총알을 비활성화하여 재사용 가능한 상태로 변경
        bulletQueue.Enqueue(bullet); // Queue에 다시 추가
    }
}
