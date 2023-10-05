using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody playerRb; // 이동에 사용할 리지드바디 컴포넌트
    public float speed = 8f; // 이동 속력
    float xInput, zInput;
    float xSpeed, zSpeed;
	GameManager gameManager;
    private void Start()
    {
		gameManager = FindObjectOfType<GameManager>();

		playerRb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        xInput = Input.GetAxis("Horizontal");
        zInput = Input.GetAxis("Vertical");

        xSpeed = xInput * speed;
        zSpeed = zInput * speed;

        Vector3 newVelocity = new Vector3(xSpeed, 0f, zSpeed);

        playerRb.velocity = newVelocity;
    }

    void InputKey()
    {
        if (Input.GetKey(KeyCode.UpArrow) == true)
        {
            playerRb.AddForce(0f, 0f, speed);
        }

        if (Input.GetKey(KeyCode.DownArrow) == true)
        {
            playerRb.AddForce(0f, 0f, -speed);
        }

        if (Input.GetKey(KeyCode.RightArrow) == true)
        {
            playerRb.AddForce(speed, 0f, 0f);
        }

        if (Input.GetKey(KeyCode.LeftArrow) == true)
        {
            playerRb.AddForce(-speed, 0f, 0f);
        }

    }

    public void Die()
	{
        gameObject.SetActive(false);

		gameManager.EndGame();
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.tag == "ScoreBullet")
		{
			gameManager.score++;
		}
	}
}
