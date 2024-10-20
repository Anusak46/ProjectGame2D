using UnityEngine;

public class CoinCollector : MonoBehaviour
{
    public GameObject coin;
    public GameObject star;
    private bool isCoinCollected;

    void Start()
    {
        isCoinCollected = false;
        star.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && !isCoinCollected)
        {
            CollectCoin();
        }
    }

    private void CollectCoin()
    {
        coin.SetActive(false);
        star.SetActive(true);
        isCoinCollected = true;
    }
}
