using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shot : MonoBehaviour
{

    private Rigidbody _rigidbody;
    [SerializeField]
    float SPEED = 10;
    [SerializeField]
    GameObject player;

    private bool isStart;

    void Start()
    {
        isStart = false;
    }

    void Update()
    {
        if (!isStart)
        {
            if (Input.GetMouseButtonDown(0))
            {
                isStart = true;
                _rigidbody = this.gameObject.GetComponent<Rigidbody>();
                _rigidbody.AddForce(new Vector3(SPEED, SPEED, 0));
            }
            transform.position = new Vector3(player.transform.position.x, player.transform.position.y + 1, transform.position.z);
        }
    }

	void OnCollisionEnter(Collision collision)
	{
        if(collision.gameObject.tag == "Enemy"){
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.tag == "Player" && Input.GetKey(KeyCode.Z))
        {
            _rigidbody.velocity = new Vector3(Mathf.Abs(_rigidbody.velocity.x) * -1, _rigidbody.velocity.y, 0);
        }

        if (collision.gameObject.tag == "Player" && Input.GetKey(KeyCode.C))
        {
            _rigidbody.velocity = new Vector3(Mathf.Abs(_rigidbody.velocity.x), _rigidbody.velocity.y, 0);
        }
	}
}
