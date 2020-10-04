using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{


    public Vector3 targetAxis;
    public bool IsStage = true;
    public bool RandomRotation = true;
    public bool RandomSpeed = true;

    private Vector2 speedRange = new Vector2(10, 20);
    [SerializeField] private float speed = 10f;

    private void Start()
    {
        if (RandomSpeed)
            speed = Random.Range(speedRange.x, speedRange.y) * (Random.Range(0, 2) * 2 - 1);

        if (RandomRotation)
            targetAxis = new Vector3(Random.Range(-1, 1), Random.Range(-1, 1), Random.Range(-1, 1));
    }

    void Update()
    {
        if (IsStage)
        {
            if (!GetComponent<StageController>().CurrentLoop)
                transform.Rotate(targetAxis * Time.deltaTime * speed);
            else
                transform.Rotate(Vector3.up * Time.deltaTime * speed);

        }
        else
            transform.Rotate(targetAxis * Time.deltaTime * speed);
    }
}
