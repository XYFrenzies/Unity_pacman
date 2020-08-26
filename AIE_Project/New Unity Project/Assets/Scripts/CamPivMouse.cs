using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamPivMouse : MonoBehaviour
{
    public float turnSpeed;
    public Transform player;
    private Vector3 playerOffset;
    // Start is called before the first frame update
    void Start()
    {
        playerOffset = new Vector3(player.position.x, player.position.y + 8.0f, player.position.z + 8.0f);
    }
    // Update is called once per frame
    void LateUpdate()
    {
        playerOffset = Quaternion.AngleAxis(Input.GetAxis("Mouse X") * turnSpeed, Vector3.up) * playerOffset;
        playerOffset = Quaternion.AngleAxis(Input.GetAxis("Mouse Y") * turnSpeed, Vector3.right) * playerOffset;
        transform.position = player.position + playerOffset;


        if (Input.GetMouseButton(0))
        {

            transform.LookAt(player.position);


            //transform.position = player.position + playerOffset;
            //transform.LookAt(player.position);
        }

    }
}
