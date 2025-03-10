using UnityEngine;
using System.Collections;

public class FishCrashSpear: MonoBehaviour
{
    Collider2D colider2D;
    public GameObject parent;
    public GameObject surprise;
    public GameObject target;
    private void Start()
    {
        colider2D = GetComponent<Collider2D>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Spear"))
        {
            SpearMiss();
            StartCoroutine(SpearMiss());
        }
    }
    void SpeedUp()
    {
        parent.GetComponent<FishMove>().speedUp = 2.5f;
    }
    void SpeedDown()
    {
        parent.GetComponent<FishMove>().speedUp = 1f;
    }
    IEnumerator SpearMiss()
    {
        surprise.SetActive(true);
        yield return new WaitForSeconds(0.15f);
        SpeedUp();
        yield return new WaitForSeconds(0.65f);
        SpeedDown();
        surprise.SetActive(false);

    }
}
