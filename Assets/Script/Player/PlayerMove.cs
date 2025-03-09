using UnityEngine;
using System.Collections;

public class PlayerMove : MonoBehaviour
{
    //public float maxSpeed = 5f; // 최대 속도
    //public float acceleration = 3f; // 가속도
    //public float deceleration = 5f; // 감속도
    //public float turnSpeed = 100f; // 회전 속도 (높을수록 빠르게 회전)

    //private float currentSpeed = 0f; // 현재 속도
    //private float moveInput;
    //private float turnInput;

    //void Update()
    //{
    //    // 전진/후진 입력 받기 (W/S)
    //    moveInput = Input.GetAxis("Vertical"); // W(1) / S(-1)

    //    // 좌우 회전 입력 받기 (A/D)
    //    turnInput = Input.GetAxis("Horizontal"); // A(-1) / D(1)

    //    // 가속 및 감속
    //    if (moveInput != 0)
    //    {
    //        currentSpeed = Mathf.Lerp(currentSpeed, moveInput * maxSpeed, acceleration * Time.deltaTime);
    //    }
    //    else
    //    {
    //        currentSpeed = Mathf.Lerp(currentSpeed, 0, deceleration * Time.deltaTime); // 서서히 멈춤
    //    }

    //    // 이동 적용
    //    transform.position += transform.up * currentSpeed * Time.deltaTime; // 차량이 보는 방향으로 이동

    //    float turnAmount = turnInput * turnSpeed * Time.deltaTime; // 속도에 따라 회전량 조절
    //    transform.Rotate(Vector3.forward, -turnAmount); // Z축 기준으로 회전

    //}

    public float maxSpeed; // 최대 속도
    public float acceleration; // 가속도
    public float deceleration; // 감속도

    public float moveForce;  // 전진/후진에 사용할 힘
    public float reverseDecelerationMultiplierf; // 반대 방향 감속 가속 배율


    public float turnSpeed; // 회전 속도 (높을수록 빠르게 회전)

    private Rigidbody2D rb;
    private Vector3 windDiration;
    private float moveInput;
    private float turnInput;
    private Vector3 pivotPosition;
    private float decelerationForce = 5; //마찰력 (감속 힘수치)
    private float windResetTime;
    public Vector3 pivotOffset = new(0, 0, 1);

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        moveInput = Input.GetAxis("Vertical"); // W(1) / S(-1)
        turnInput = Input.GetAxis("Horizontal"); // A(-1) / D(1)
        transform.Translate(windDiration * Time.deltaTime , Space.World); // 바람 방향으로 힘 작용
    }
    private void OnEnable()
    {
        StartCoroutine(WindStartCoroutine());
    }
    void FixedUpdate()
    {
        if (turnInput != 0)
        {
            // 현재 Transform 위치에서 피벗 오프셋 적용
            pivotPosition = transform.position + pivotOffset;

            // Z축 기준으로 회전
            float rotationAmount = -turnInput * turnSpeed * Time.fixedDeltaTime;
            transform.RotateAround(pivotPosition, Vector3.forward, rotationAmount);
        }
        if (moveInput != 0)
        {
            Vector2 forceDirection = transform.up * moveInput; // "앞 방향" 또는 "뒤 방향"
            rb.AddForce(forceDirection * moveForce, ForceMode2D.Force);
        }
        // 현재 속도를 가져옵니다.
        Vector2 currentVelocity = rb.GetPointVelocity(pivotPosition);
        // 최고 속도 제한
        if (currentVelocity.magnitude > maxSpeed)
        {
            rb.linearVelocity = currentVelocity.normalized * maxSpeed;
        }

        // 속도가 거의 0이 아니면 (즉, 움직이고 있으면)
        if (currentVelocity.magnitude > 0.1f)
        {
            // 이동 방향의 반대 방향으로 힘을 가합니다.
            Vector2 decelerationDirection = -currentVelocity.normalized; // 반대 방향
            rb.AddForce(decelerationDirection * decelerationForce, ForceMode2D.Force);
        }
    }
    IEnumerator WindStartCoroutine() // 바람에 밀림 ,상점 제외
    {
        yield return new WaitForSeconds(0.5f);
        windDiration = GameManager.Instance.WindDiraction();
        windResetTime = GameManager.Instance.WindResetTime();
        if (windDiration.x == 0 && windDiration.y == 0  && windDiration.z == 0) { yield break; }
        yield return new WaitForSeconds(windResetTime - 0.5f); 

        StartCoroutine(WindStartCoroutine());
    }
}
