using System.Collections.Generic;
using UnityEngine;
public class CatchList : MonoBehaviour
{
    public List<GameObject> catchList;
    private int catchCount = 0;

    void Start()
    {

    }
    public void Catch()
    {
        catchList[catchCount].SetActive(true);
        catchCount++;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Fish"))
        {
            Catch();
        }
    }
}