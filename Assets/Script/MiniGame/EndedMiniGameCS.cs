using UnityEngine;
using UnityEngine.SceneManagement;

public class EndedMiniGameCS : MonoBehaviour
{
    public GameObject player;
    private int spearCount = 5;
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Spear"))
        {
            spearCount--;
            if (spearCount == 0)
            {
                player.GetComponent<Bbb10311031_PlayerAttack>().attackCount = -1;
                Invoke("EndedGame", 3.0f);
            }
        }
    }
    public void EndedGame()
    {
        Camera mainCamera = Camera.main;
        Vector3 position = player.transform.position;
        position.z = -10;
        mainCamera.transform.position = position;
        Camera.main.orthographicSize -= 5 * 1;
        Invoke("EndedFishing", 3.0f);
    }
    private void EndedFishing()
    {
        SceneManager.LoadScene(1);
    }
}
