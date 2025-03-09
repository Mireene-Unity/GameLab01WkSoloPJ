using UnityEngine;
using UnityEngine.UIElements;

public class FishMove : MonoBehaviour
{
    public float speedUp;
    static float defaultSpeed = 4;
    void Update()
    {
         transform.Translate(Vector3.left *speedUp* defaultSpeed* Time.deltaTime);
        if (transform.position.x < -15)
        {
            Destroy(gameObject);
        }
    }
}
