using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.InputSystem;


public class PlayerMovement : MonoBehaviour
{
    //public TextMeshProUGUI countText;
    public float moveSpeed = 2;

    private Rigidbody rb;

    private Controls controls;

    // Start is called before the first frame update


    private void Awake()
    {
        controls = new Controls();
        controls.Player.Move.performed += OnMove;

        controls.Enable();
    }
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        
        // SetCountText();
    }

    void OnMove(InputAction.CallbackContext callback)
    {
        
        Vector3 inputForce = callback.action.ReadValue<Vector3>();
        rb.AddForce(inputForce * moveSpeed);
        rb.AddForce(0, 0.8f, 0);
    }

    // Update is called once per frame
    void Update()
    {
        Keyboard kb = InputSystem.GetDevice<Keyboard>();

        if (kb.wKey.wasPressedThisFrame)
        {

        }

    }
    //private void OnTriggerEnter(Collider other)
    //{
    //    //if (other.gameObject.tag == "PickUp")
    //    //{
    //    //    other.gameObject.SetActive(false);
    //    //    //Destroy(other.gameObject);
    //    //    count = count + 1;
    //    //    //SetCountText();
    //    //}

    //}
    //private void SetCountText()
    //{
    //    countText.text = countTeam1.ToString() + " : " + countTeam2.ToString();
    //}
}
