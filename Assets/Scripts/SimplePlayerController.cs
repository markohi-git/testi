using Photon.Pun;
using UnityEngine;

public class SimplePlayerController : MonoBehaviour
{
    PhotonView photonView;
    Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        photonView = GetComponent<PhotonView>();
    }
    // Update is called once per frame
    void Update()
    {
        if (photonView.IsMine)
        {
            //Move Front/Back
            if (Input.GetKey(KeyCode.W))
            {
                transform.Translate(transform.forward * Time.deltaTime * 2.45f, Space.World);
            }
            else if (Input.GetKey(KeyCode.S))
            {
                transform.Translate(-transform.forward * Time.deltaTime * 2.45f, Space.World);
            }

            //Rotate Left/Right
            if (Input.GetKey(KeyCode.A))
            {
                transform.Rotate(new Vector3(0, -14, 0) * Time.deltaTime * 4.5f, Space.Self);
            }
            else if (Input.GetKey(KeyCode.D))
            {
                transform.Rotate(new Vector3(0, 14, 0) * Time.deltaTime * 4.5f, Space.Self);
            }
        }
    }
}
