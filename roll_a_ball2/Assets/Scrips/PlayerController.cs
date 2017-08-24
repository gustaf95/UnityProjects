using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{

    public float speed;
    public Rigidbody rb;
    public Text CountText;

    private int count;

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        DisplayCountText();
    }

    // Update is called once per frame
    void Update()
    {

    }

    // FixedUpdate is called once per frame before applying physic effect
    private void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0f, moveVertical);

        rb.AddForce(movement * speed);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PickUp"))
        {
            other.gameObject.SetActive(false);
            count = count + 1;
            DisplayCountText();
        }
    }

    void DisplayCountText()
    {
        CountText.text = "Count: " + count.ToString();
    }

    //void OnCollisionEnter(Collision collision)
    //{
    //    if (collision.gameObject.CompareTag("PickUp"))
    //        collision.gameObject.SetActive(false);
    //}

    //void OnCollisionEnter(Collision collision)
    //{
    //    collision.gameObject.SetActive(false);
    //}
}

