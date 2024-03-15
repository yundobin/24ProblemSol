using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;

    // 다른 스크립트에서 GameManager.Instance로 접근할 수 있도록 함
    public static GameManager Instance
    {
        get
        {
            if (instance == null)
            {
                // 씬에서 GameManager를 찾아서 인스턴스화하거나 새로운 오브젝트를 만들어서 할당
                instance = FindObjectOfType<GameManager>();
                if (instance == null)
                {
                    GameObject obj = new GameObject("GameManager");
                    instance = obj.AddComponent<GameManager>();
                }
            }
            return instance;
        }
    }
}