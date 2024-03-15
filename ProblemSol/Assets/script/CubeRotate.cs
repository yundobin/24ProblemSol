using UnityEngine;

public class CubeRotate : MonoBehaviour
{
    public Transform rotationCenter; // 회전 중심점
    public int power = 90;
    private int r;

    void Update()
    {
        r = Random.Range(90, 200);
        // 회전 중심점을 중심으로 회전
        transform.RotateAround(rotationCenter.position, Vector3.forward, power * Time.deltaTime);
        if (this.transform.position.y >= 0.8)
        {
            power = -r;
        }
        else if(this.transform.position.y <= -0.8)
        {
            power = r;
        }
    }
}