using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public GameObject canvas;
    public GameObject playerPrefab;
    private GameObject playerInstance;
    private int playerCount = 0;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void EndLevel()
    {
        canvas.SetActive(true);

        if (playerInstance != null)
        {
            Destroy(playerInstance);
            playerCount = 0;
        }
    }

    public void SpawnPlayer(Vector3 position, Quaternion rotation)
    {
        if (playerCount < 1)
        {
            playerInstance = Instantiate(playerPrefab, position, rotation);
            playerCount++;
        }
    }
}
