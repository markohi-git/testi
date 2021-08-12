// BasicMovement.cs
using UnityEngine;
using Photon.Pun;

public class BasicMovement : MonoBehaviour
{
    public float speed;
    public float rotationSpeed;
    [SerializeField] private Camera m_Camera;

    Rigidbody rb;
    PhotonView photonView;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        photonView = GetComponent<PhotonView>();
        if (!photonView.IsMine)
        {
            Destroy(m_Camera);
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (photonView.IsMine)
        {
            Move();
        }
    }

    void Move()
    {
        /*float horizontal = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        float vertical = Input.GetAxis("Vertical") * speed * Time.deltaTime;

        Vector3 newVector = new Vector3(horizontal, 0, vertical);

        rb.position += newVector;
        */
        if (Input.GetKey("space"))
        {
            rb.AddForce(new Vector3(0, 0.5f, 0), ForceMode.Impulse);
        }

        float translation = Input.GetAxis("Vertical") * speed;
        float rotation = Input.GetAxis("Horizontal") * rotationSpeed;

        // Make it move 10 meters per second instead of 10 meters per frame...
        translation *= Time.deltaTime;
        rotation *= Time.deltaTime;

        // Move translation along the object's z-axis
        transform.Translate(0, 0, translation);

        // Rotate around our y-axis
        transform.Rotate(0, rotation, 0);

       
    }
}
