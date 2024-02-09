using UnityEngine;

public class MonsterMovement : MonoBehaviour
{
    public Vector2 targetPoint; // ��ǥ ����
    public float moveSpeed = 5f; // ���� �̵� �ӵ�

    private void Update()
    {
        // ���� ��ġ���� ��ǥ ���� �������� �̵�
        transform.position = Vector2.MoveTowards(transform.position, targetPoint, moveSpeed * Time.deltaTime);

        // ���� ��ǥ ������ �����ߴٸ� ����
        if (Vector2.Distance(transform.position, targetPoint) < 0.1f)
        {
            // ���⼭ ���ϴ� �߰� ���� ���� ����
            // ��: ���Ͱ� ��ǥ ������ �������� �� ���� ������ �����ϰų� �ٸ� �������� �̵��ϴ� ��
            Debug.Log("��ǥ ������ �����߽��ϴ�!");
            enabled = false; // �̵� ��ũ��Ʈ�� ��Ȱ��ȭ�Ͽ� ����
        }
    }
}
