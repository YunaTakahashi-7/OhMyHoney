using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //移動スピード
    float speed = 2.5f;
    //方向転換のスピード
    float angleSpeed = 200;
    //Rigidbodyを入れる
    Rigidbody rb;

    public GameObject ClearTimeline;
    public GameObject GameOverTimeline;

    void Start()
    {
        //Rigidbodyコンポーネントを取得
        rb = GetComponent<Rigidbody>();
        //RigidbodyのConstraintsを3つともチェック入れて
        //勝手に回転しないようにする
        rb.constraints = RigidbodyConstraints.FreezeRotation;
    }
    void Update()
    {
        //WSキー、↑↓キーで移動する
        float z = Input.GetAxisRaw("Vertical") * Time.deltaTime * speed;
        //前進の後退
        //後退は前進の3分の1のスピードになる
        if (z > 0)
        {
            transform.position += transform.forward * z;
        }
        else
        {
            transform.position += transform.forward * z / 3;
        }
        //ADキー、←→キーで方向を替える
        float x = Input.GetAxisRaw("Horizontal") * Time.deltaTime * angleSpeed;
        transform.Rotate(Vector3.up * x);

        ////移動
        //if (Input.GetKey(KeyCode.UpArrow))
        //{
        //    transform.position += new Vector3(0, 0, 0.02f);
        //}
        //else if (Input.GetKey(KeyCode.DownArrow))
        //{
        //    transform.position += new Vector3(0, 0, -0.02f);
        //}
        //else if (Input.GetKey(KeyCode.D))
        //{
        //    transform.position += new Vector3(1 * Time.deltaTime, 0, 0);
        //}
        //else if (Input.GetKey(KeyCode.A))
        //{
        //    transform.position += new Vector3(-1 * Time.deltaTime, 0, 0);
        //}
        //else
        //{
        //    transform.position += new Vector3(0, 0, 0);
        //}
        //回転
        //if (Input.GetKey(KeyCode.G))
        //{
        //    transform.Rotate(0f, -50 * Time.deltaTime, 0f);
        //}
        //else if (Input.GetKey(KeyCode.H))
        //{
        //    transform.Rotate(0f, 50 * Time.deltaTime, 0f);
        //}
        //else
        //{
        //    transform.Rotate(0f, 0f, 0f);
        //}
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "honey")
        {
            ClearTimeline.SetActive(true);
        }
        if (other.gameObject.tag == "enemy")
        {
            GameOverTimeline.SetActive(true);
        }
    }
}
