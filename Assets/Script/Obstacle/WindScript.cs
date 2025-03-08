using UnityEngine;
using System.Collections;

public class WindScript : MonoBehaviour
{
    public float speed; // 스크롤 속도
    public float windPower; //바람 세기
    public float windResetTime;
    private Vector3 startPoint = new(0, 0, 0); // 초기화 위치 (시작점)
    private Transform endPoint; // 끝점 Transform
    private Vector3 restartPoint;

    void Start()
    {
        StartCoroutine(WindStartCoroutine());
    }

    void Update()
    {
        // 오른쪽으로 이동
        transform.Translate(Vector3.right * speed * Time.deltaTime);

        // 실제 Z축 회전 값을 가져와 MoveDirection 호출
        int currentZRotation = Mathf.RoundToInt(transform.eulerAngles.z);
        MoveDirection(currentZRotation);
    }
    IEnumerator WindStartCoroutine()
    {
        WindStart();
        yield return new WaitForSeconds(windResetTime);

        StartCoroutine(WindStartCoroutine());
    }

    void WindStart()
    {

        int WindRotation = Random.Range(0, 361); // 초기 Z축 회전 값 설정
        transform.rotation = Quaternion.Euler(0, 0, WindRotation);
        transform.position = new(0, 0, 0);
        // 첫 번째 자식 오브젝트를 끝점으로 설정
        endPoint = transform.GetChild(0);
        restartPoint = endPoint.position;

        Vector3 WindMoveVector = restartPoint - startPoint;
        Vector3 WindDiraction = WindMoveVector.normalized * windPower;
        GameManager.Instance.SetWindDiraction(WindDiraction, windResetTime);
    }

    void MoveDirection(int zRotation)
    {
        // 정면 방향
        if ((zRotation >= 0 && zRotation < 90) || (zRotation > 270 && zRotation <= 360))
        {
            if (transform.position.x > restartPoint.x)
            {
                transform.position = startPoint;
            }
        }

        // 뒤쪽 방향
        else if (zRotation > 90 && zRotation < 270)
        {
            if (transform.position.x < restartPoint.x)
            {
                transform.position = startPoint;
            }
        }

        // 위 방향
        if (zRotation == 90)
        {
            if (transform.position.y > restartPoint.y)
            {
                transform.position = startPoint;
            }
            return;
        }

        // 아래 방향
        if (zRotation == 270)
        {
            if (transform.position.y < restartPoint.y)
            {
                transform.position = startPoint;
            }
            return;
        }
    }
}
