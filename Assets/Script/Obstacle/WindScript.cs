using UnityEngine;
using System.Collections;

public class WindScript : MonoBehaviour
{
    public float speed; // ��ũ�� �ӵ�
    public float windPower; //�ٶ� ����
    public float windResetTime;
    private Vector3 startPoint = new(0, 0, 0); // �ʱ�ȭ ��ġ (������)
    private Transform endPoint; // ���� Transform
    private Vector3 restartPoint;

    void Start()
    {
        StartCoroutine(WindStartCoroutine());
    }

    void Update()
    {
        // ���������� �̵�
        transform.Translate(Vector3.right * speed * Time.deltaTime);

        // ���� Z�� ȸ�� ���� ������ MoveDirection ȣ��
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

        int WindRotation = Random.Range(0, 361); // �ʱ� Z�� ȸ�� �� ����
        transform.rotation = Quaternion.Euler(0, 0, WindRotation);
        transform.position = new(0, 0, 0);
        // ù ��° �ڽ� ������Ʈ�� �������� ����
        endPoint = transform.GetChild(0);
        restartPoint = endPoint.position;

        Vector3 WindMoveVector = restartPoint - startPoint;
        Vector3 WindDiraction = WindMoveVector.normalized * windPower;
        GameManager.Instance.SetWindDiraction(WindDiraction, windResetTime);
    }

    void MoveDirection(int zRotation)
    {
        // ���� ����
        if ((zRotation >= 0 && zRotation < 90) || (zRotation > 270 && zRotation <= 360))
        {
            if (transform.position.x > restartPoint.x)
            {
                transform.position = startPoint;
            }
        }

        // ���� ����
        else if (zRotation > 90 && zRotation < 270)
        {
            if (transform.position.x < restartPoint.x)
            {
                transform.position = startPoint;
            }
        }

        // �� ����
        if (zRotation == 90)
        {
            if (transform.position.y > restartPoint.y)
            {
                transform.position = startPoint;
            }
            return;
        }

        // �Ʒ� ����
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
