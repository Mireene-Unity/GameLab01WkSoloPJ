using UnityEngine;

public class SpearRotate : MonoBehaviour
{
    public GameObject spear;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        MousePosition();
    }
    void MousePosition()
    {
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 direction = mousePosition - (Vector2)spear.transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        spear.transform.rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);
    }

}
