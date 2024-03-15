using UnityEngine;

public class BulletCheck : MonoBehaviour
{
    private BulletMake bulletMake;

    void Start()
    {
        bulletMake = FindObjectOfType<BulletMake>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bullet"))
        {
            // 총알을 재사용 가능한 상태로 돌려줌
            bulletMake.ReturnBullet(other.gameObject);
            // 총알의 위치를 BulletMake 스크립트에서 지정한 초기 위치로 이동시킴
            other.transform.position = bulletMake.transform.position;
        }
    }
}
