using UnityEngine;
using Datastructure;

public class BulletMake : MonoBehaviour
{
    private Stack<GameObject> bulletStack; // Queue 대신 Stack 사용
    public GameObject bulletPrefab; // 총알 프리팹

    void Start()
    {
        bulletStack = new Stack<GameObject>(); // Queue 대신 Stack으로 변경

        // 10개의 Bullet을 Stack에 넣기
        for (int i = 0; i < 10; i++)
        {
            GameObject bullet = Instantiate(bulletPrefab); // Bullet 프리팹을 인스턴스화
            bullet.SetActive(false); // 초기에는 비활성화 상태로 설정
            bulletStack.Push(bullet); // Stack에 추가 (Enqueue 대신 Push 사용)
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
        if (!bulletStack.IsEmpty()) // IsEmpty 메서드 사용
        {
            GameObject bullet = bulletStack.Pop(); // Dequeue 대신 Pop 사용
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
        bulletStack.Push(bullet); // Queue 대신 Stack 사용 (Enqueue 대신 Push 사용)
    }
}
