using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class Enermy : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 3f;
    [SerializeField] private float rotationSpeed = 10f;
    [SerializeField] private float minChangeDirectionTime = 1f;
    [SerializeField] private float maxChangeDirectionTime = 3f;
    [SerializeField] private Transform rangeTransform;
    [SerializeField] private bool isChasing = false;
    [SerializeField] private Camera subCam;
    

    private GameObject player;
    private Vector3 initialPosition;
    private Vector3 minPosition;
    private Vector3 maxPosition;
    private Vector3 moveDirection;
    private float nextChangeDirectionTime;
    private bool isPlayerVisible = false;
    private Vector3 targetPosition;
    private Quaternion targetRotation;

    void Start()
    {
        initialPosition = transform.position;
        player = GameObject.FindGameObjectWithTag("Player");

        if (rangeTransform == null)
        {
            Debug.LogError("Range Transform이 할당되어 있지 않습니다.");
            return;
        }

        if (subCam == null)
        {
            subCam = Camera.main;
        }

        minPosition = rangeTransform.position - rangeTransform.localScale / 2f;
        maxPosition = rangeTransform.position + rangeTransform.localScale / 2f;

        moveDirection = Vector3.forward;
        nextChangeDirectionTime = Time.time + Random.Range(minChangeDirectionTime, maxChangeDirectionTime);

        
    }

    void Update()
    {
        if (isChasing == false)
        {
            if (IsPlayerInCameraFrustum())
            {
                isChasing = true;
            }
            moveSpeed = 3.0f;
            rotationSpeed = 10.0f;
            Vector3 direction = (initialPosition - transform.position).normalized;
            Vector3 newPosition = transform.position + moveDirection * moveSpeed * Time.deltaTime;

            if (newPosition.x < minPosition.x || newPosition.x > maxPosition.x ||
                newPosition.z < minPosition.z || newPosition.z > maxPosition.z)
            {
                newPosition = transform.position;
            }

            transform.position = newPosition;

            if (Time.time >= nextChangeDirectionTime)
            {
                int randomAxis = Random.Range(0, 2);
                float randomSign = Random.Range(0, 2) * 2 - 1;

                moveDirection = randomAxis == 0 ? Vector3.right * randomSign : Vector3.forward * randomSign;
                nextChangeDirectionTime = Time.time + Random.Range(minChangeDirectionTime, maxChangeDirectionTime);
            }
            transform.rotation = Quaternion.LookRotation(moveDirection);
            
        }
        else if(isChasing == true)
        {
            if (player == null)
                return;

            if (IsPlayerInCameraFrustum())
            {
                ChasePlayer();
                isPlayerVisible = true;
            }
            else
            {
                if(isPlayerVisible)
                {
                    moveSpeed = 0f;
                    StartCoroutine(WaitForSecondsAndRotate(3.0f));
                    isPlayerVisible = false;
                }
            }
        }
    }
    bool IsPlayerInCameraFrustum()
    {
        if (subCam == null)
        {
            Debug.LogError("카메라가 지정되지 않았습니다.");
            return false;
        }

        Plane[] frustumPlanes = GeometryUtility.CalculateFrustumPlanes(subCam);
        return GeometryUtility.TestPlanesAABB(frustumPlanes, player.GetComponent<Collider>().bounds);
    }
    void ChasePlayer()
    {
        moveSpeed = 5.0f;
        targetPosition = player.transform.position;
        targetRotation = Quaternion.LookRotation(targetPosition - transform.position);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);
    }
    IEnumerator WaitForSecondsAndRotate(float seconds)
    {
        moveSpeed = 0f;
        rotationSpeed = 0f;
        targetPosition = transform.position;
        transform.Rotate(0, -90, 0); // 회전
        yield return new WaitForSeconds(seconds); // 대기

        transform.Rotate(0, 180, 0); // 회전
        yield return new WaitForSeconds(seconds); // 대기

        moveSpeed = 5f;
        isPlayerVisible = false;
        isChasing = false;
    }


    private void OnDrawGizmosSelected()
    {
        if (rangeTransform == null)
            return;

        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(rangeTransform.position, rangeTransform.localScale);
    }
}
