using UnityEngine;

public class CollectibleManagerN2 : MonoBehaviour
{
    public static CollectibleManagerN2 Instance;

    private int collectibleCount;

    private void Awake()
    {
        Instance = this;
    }

    public void AddCollectible()
    {
        collectibleCount++;

        Debug.Log("Collectibles: " + collectibleCount);
    }

    public int GetCollectibleCount()
    {
        return collectibleCount;
    }
}
