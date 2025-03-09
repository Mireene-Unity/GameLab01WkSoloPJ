using UnityEngine;

public class MiniPlayerMove : MonoBehaviour
{
    public float moveSpeed;
    public float moveRange;
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMove();
    }
    void PlayerMove()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * horizontalInput * moveSpeed * Time.deltaTime);

        float newXPosition = transform.position.x + (horizontalInput * moveSpeed * Time.deltaTime);

        // X�� �̵� ���� ����
        newXPosition = Mathf.Clamp(newXPosition, -moveRange, moveRange);

        // ���ѵ� ��ġ
        transform.position = new Vector3(newXPosition, transform.position.y, transform.position.z);
    }
}
