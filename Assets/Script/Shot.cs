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
    [SerializeField]
    GameObject scoreObj;


    private bool isStart;
    private bool isEnd;
    private AudioSource  a1;
    private int score;
    [SerializeField]
    List<AudioClip> mitoClip = new List<AudioClip>();
    [SerializeField]
    List<AudioClip> deroClip = new List<AudioClip>();
    [SerializeField]
    List<AudioClip> eruClip = new List<AudioClip>();
    [SerializeField]
    AudioClip iwaiwaClip;
    private AudioClip audioClip;

    void Start()
    {
        isStart = false;
        isEnd = false;
        score = 1000;
        a1 = this.gameObject.AddComponent<AudioSource> ();
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
                GameObject startText = GameObject.FindGameObjectWithTag("Start");
                if (startText)
                {
                    Destroy(startText);
                }
            }
            transform.position = new Vector3(player.transform.position.x, player.transform.position.y + 1, transform.position.z);
        } else {
            _rigidbody.velocity = _rigidbody.velocity * 1.0003f;
            if(gameObject.transform.position.y <= -6){
                isStart = false;
                _rigidbody.velocity = new Vector3(0.0f,0.0f,0.0f);
                score -= 100;
            }
        }

        // ゲームクリア処理
        if(!isEnd && GameObject.FindGameObjectsWithTag("Enemy").Length <= 3){
            GameObject[] objs = GameObject.FindGameObjectsWithTag("Enemy");
            foreach(GameObject obj in objs){
                Destroy(obj);
            }
            _rigidbody.velocity = new Vector3(0.0f,0.0f,0.0f);
            GameObject instantiateObj = Instantiate(scoreObj) as GameObject;
            TextMesh textMesh = instantiateObj.GetComponent<TextMesh>();
            score = score < 0 ? 0 : score;
            textMesh.text = ("Congratulations!\nscore " + score);
            isEnd = true;
        }
    }

	void OnCollisionEnter(Collision collision)
	{
        if(collision.gameObject.tag == "Enemy"){
            int type = Random.Range(0, 2);
            string number = collision.gameObject.name.Replace("(Clone)","").Replace("Bloc_", "");

            if(number == "0")
            {
                audioClip = mitoClip[type];
            }
            else if(number == "1")
            {
                audioClip = deroClip[type];
            }
            else if (number == "2")
            {
                audioClip = eruClip[type];
            }

            if (Random.Range(0, 20) == 0)
            {
                audioClip = iwaiwaClip;
            }

            a1.clip = audioClip;
            a1.volume = 0.25f;
            a1.Play();

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
