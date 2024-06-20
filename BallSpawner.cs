using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSpawner : MonoBehaviour
{
    public GameObject ballPrefab; // �� ������
    public float spawnInterval = 1.0f; // �� ���� ����
    public float minX = -8.0f; // ���� ������ �ּ� X ��ġ
    public float maxX = 8.0f; // ���� ������ �ִ� X ��ġ

    private void Start()
    {
        // �ֱ������� ���� �����ϴ� �ڷ�ƾ�� �����մϴ�.
        StartCoroutine(SpawnBall());
    }

    private IEnumerator SpawnBall()
    {
        while (true)
        {
            // ���� �����մϴ�.
            Instantiate(ballPrefab, GetRandomSpawnPosition(), Quaternion.identity);
            // �� ���� ���ݸ�ŭ ����մϴ�.
            yield return new WaitForSeconds(spawnInterval);
        }
    }

    private Vector3 GetRandomSpawnPosition()
    {
        // ȭ�� ����� ���� X ��ġ���� ���� �����մϴ�.
        float randomX = Random.Range(minX, maxX);
        return new Vector3(randomX, transform.position.y, 0);
    }
}
