using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    CharacterController characterController;
    float speed = 5f;
    Vector3 move = Vector3.zero;
    Vector3 velocity = Vector3.zero;
    float pitch = 0f;
    public Transform cameraPivot;

    // Start is called before the first frame update
    public void OnEnable()
    {
        characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, Input.GetAxis("Mouse X") * 3f, 0);
        pitch -= Input.GetAxis("Mouse Y") * 3f;
        pitch = Mathf.Clamp(pitch, -60f, 60f);
        cameraPivot.localEulerAngles = new Vector3(pitch, 0, 0);
        move.x = Input.GetAxisRaw("Horizontal");
        move.z = Input.GetAxisRaw("Vertical");
        move = Vector3.ClampMagnitude(move, 1f);
        velocity = transform.TransformVector(move) * speed;
        characterController.SimpleMove(velocity);
    }
}
