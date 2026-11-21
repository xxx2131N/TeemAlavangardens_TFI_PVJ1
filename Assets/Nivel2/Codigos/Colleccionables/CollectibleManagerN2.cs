using UnityEngine;

public class CollectibleManagerN2 : MonoBehaviour
{
    public static CollectibleManagerN2 Instance;

    private int collectibleCount;

    [SerializeField] private CollectibleUI collectibleUI;

    private void Awake()
    {
        Instance = this;
    }

    public void AddCollectible()
    {
        collectibleCount++;

        Debug.Log("Collectibles: " + collectibleCount);

        collectibleUI.UpdateCounter(collectibleCount);
    }

    public int GetCollectibleCount()
    {
        return collectibleCount;
    }
}
