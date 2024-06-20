using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSpawner : MonoBehaviour
{
    public GameObject ballPrefab; // 공 프리팹
    public float spawnInterval = 1.0f; // 공 생성 간격
    public float minX = -8.0f; // 공이 생성될 최소 X 위치
    public float maxX = 8.0f; // 공이 생성될 최대 X 위치

    private void Start()
    {
        // 주기적으로 공을 생성하는 코루틴을 시작합니다.
        StartCoroutine(SpawnBall());
    }

    private IEnumerator SpawnBall()
    {
        while (true)
        {
            // 공을 생성합니다.
            Instantiate(ballPrefab, GetRandomSpawnPosition(), Quaternion.identity);
            // 공 생성 간격만큼 대기합니다.
            yield return new WaitForSeconds(spawnInterval);
        }
    }

    private Vector3 GetRandomSpawnPosition()
    {
        // 화면 상단의 랜덤 X 위치에서 공을 생성합니다.
        float randomX = Random.Range(minX, maxX);
        return new Vector3(randomX, transform.position.y, 0);
    }
}
