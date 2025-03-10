using UnityEngine;

public class Catch : MonoBehaviour
{
    private GameObject spear;
    private bool isCatch = false;
    FishMove fishMove;
    void Start()
    {
    } 
    void Update()
    {
        Follow();
    }
    void Follow()//작살따라가기
    {
        if (isCatch)
        {
            if (spear == null)
            {
                Destroy(transform.parent.gameObject);
                return;
            }
            transform.parent.position = spear.transform.position;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Spear"))
        {
            spear = collision.gameObject;
            isCatch = true;
        }
    }
}
