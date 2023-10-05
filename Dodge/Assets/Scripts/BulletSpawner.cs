using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner : MonoBehaviour
{
	public GameObject[] bulletPrefabs; // 탄알 프리팹
	[SerializeField] float spawnRateMin = 0.5f; // 최소 생성 주기
	[SerializeField] float spawnRateMax = 3f; // 최대 생성 주기

	Transform target; // 발사할 대상
	float spawnRate; // 생성 주기
	float timerAfterSpawn; // 최근 생성 시점에서 지난 시간

    private void Start()
    {
		timerAfterSpawn = 0f;
		spawnRate = Random.Range(spawnRateMin, spawnRateMax);
		target = FindObjectOfType<PlayerController>().transform;
	}

	private void Update()
	{
		timerAfterSpawn += Time.deltaTime;

		// 최근 생성 시점에서부터 누적된 시간이 생성 주기보다 크거나 같다면
		if (timerAfterSpawn >= spawnRate)
		{
			// 누적 시간 초기화
			timerAfterSpawn = 0f;

			// bulletPrefab의 복제본을
			// transform.position 위치와 transform.rotation 회전으로 생성
			int ran = Random.Range(0, bulletPrefabs.Length);
			GameObject bullet = Instantiate(bulletPrefabs[ran], transform.position, transform.rotation);

			// 생성된 bullet 게임 오브젝트의 정면 방향이 target을 향하도록 회전
			bullet.transform.LookAt(target);

			// 다음 생성 간격을 spawnRateMin, spawnRateMax 사이에서 랜덤
			spawnRate = Random.Range(spawnRateMin, spawnRateMax);
		}

	}
}
