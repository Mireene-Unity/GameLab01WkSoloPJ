using UnityEngine;

public class GoFishing : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Spear"))
        {
            GameManager.Instance.GoInFishingScene();
        }
    }
}
