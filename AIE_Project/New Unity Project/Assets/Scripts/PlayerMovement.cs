using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerMovement : MonoBehaviour
{
    public TextMeshProUGUI countText;
    public float moveSpeed = 2;

    private Rigidbody rb;
    private int count;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        SetCountText();
    }

    // Update is called once per frame
    void Update()
    {

        Vector3 inputForce = new Vector3();

        inputForce.x = Input.GetAxis("Horizontal");
        inputForce.z = Input.GetAxis("Vertical");
        rb.AddForce(inputForce * moveSpeed);
        rb.AddForce(0, 0.8f, 0);

        //if(Input.GetButtonDown())
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "PickUp")
        {
            other.gameObject.SetActive(false);
            //Destroy(other.gameObject);
            count = count + 1;
            SetCountText();
        }
    }
    private void SetCountText() 
    {
        countText.text = "Score: " + count.ToString();
    }
}
