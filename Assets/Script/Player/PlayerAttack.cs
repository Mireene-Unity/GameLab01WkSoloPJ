using UnityEngine;

public class Bbb10311031_PlayerAttack : MonoBehaviour
{
    public GameObject bullet;
    private int maxAttackCount = 1;
    public int attackCount;  
    private int spearCount = 5;
    void Start() 
    {
        maxAttackCount += StateManager.Instance.SpearCount;
        attackCount = maxAttackCount;
    }
    void Update()
    {

        // 마우스 클릭 시 이동 시작
        if (Input.GetMouseButtonDown(0) && attackCount > 0)
        {
            AttackCountDown();
            GameObject bulletObj = Instantiate(bullet, transform.position
                                              ,Quaternion.Euler(transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition)));
            bulletObj.GetComponent<Spear>().targetPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }
    }

    public void AttackCountUp()
    {
        attackCount += 1;
    }

    public void AttackCountDown()
    {
        if (attackCount != 0)
        {
            attackCount -= 1;
        }
    }
}
