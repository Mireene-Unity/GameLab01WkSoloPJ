using System.Collections.Generic;
using UnityEngine;

public class SpearList : MonoBehaviour
{
    public List<GameObject> catchList;
    private int catchCount = 0;
    bool spearCountUp = false;

    void Start()
    {

    }
    public void Catch()
    {
        catchList[catchCount].SetActive(false);
        catchCount++;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Spear"))
        {
            Catch();
        }
    }
}