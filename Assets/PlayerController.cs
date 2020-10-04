using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 1f;
    public float gravity = 5f;
    private Rigidbody rb;

    private bool inverted = true;
    private void Start()
    {

        rb = GetComponent<Rigidbody>();

        ChangeParent();
    }

    private void ChangeParent()
    {
        transform.parent = LevelController.Instance.transform.GetChild(LevelController.Instance.currentStageIndex);
        // inverted = transform.parent.GetComponent<Rotator>().IsStage;
    }
    void Update()
    {
        Vector3 center = (transform.parent.position - transform.position).normalized;
        Vector3 tangent = Vector3.Cross((transform.position - transform.parent.position).normalized, transform.right);

        if (Input.GetKey(KeyCode.W))
        {
            rb.velocity = tangent * speed;
        }
        else
        {
            rb.velocity = Vector3.zero;
        }

        rb.AddForce((inverted ? -1 : 1) * gravity * center, ForceMode.Force);
        transform.rotation = Quaternion.LookRotation(tangent, center);

    }
}
