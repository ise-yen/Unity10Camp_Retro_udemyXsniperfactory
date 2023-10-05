using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
	[SerializeField] float speed = 8f;

	Rigidbody bulletRb;
    private void Start()
    {
		bulletRb = gameObject.GetComponent<Rigidbody>();
		bulletRb.velocity = transform.forward * speed;

		Destroy(gameObject, 3f); // 3초 뒤 자기 자신 파괴
    }

	private void OnTriggerEnter(Collider other)
	{
		if(other.tag == "Player"){
			if(gameObject.tag == "Bullet")
			{
				PlayerController playerController = other.GetComponent<PlayerController>();
				if (playerController != null) playerController.Die();
			}
			Destroy(gameObject);
		}
	}
}
