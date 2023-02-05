using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainMovement : MonoBehaviour
{
    Rigidbody2D trainRB;

    [SerializeField] Vector3 startPoint;
    public List<Vector3> points;
    [SerializeField] float speed, rotateSpeed, rotationModifier;
    int index;

    Vector3 startPos;

    //public bool isStart;

    private void OnEnable()
    {
        index = 0;
        startPoint = GameObject.Find("StartPoint").GetComponent<Transform>().position;
    }

    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
        //isStart = false;
        //index = 0;
        //startPoint = GameObject.Find("StartPoint").GetComponent<Transform>().position;
        //trainRB = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(points.Count == 0)
        {
            transform.position = Vector2.MoveTowards(transform.position, startPoint, speed);
            //if (Vector2.Distance(transform.position, startPoint) <= 0.05f) isStart = true;
        }
        else
        {
            transform.position = Vector2.MoveTowards(transform.position, points[index], speed);
            //LookAt(points[index].position);
            Vector3 vectorToTarget = points[index] - transform.position;
            float angle = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg - rotationModifier;
            Quaternion toRotation = Quaternion.AngleAxis(angle, Vector3.forward);
            transform.rotation = Quaternion.Slerp(transform.rotation, toRotation, rotateSpeed);
            //Quaternion toRotation = Quaternion.LookRotation(transform.forward, points[index].position);
            //transform.rotation = Quaternion.Lerp(transform.rotation, toRotation,  Time.deltaTime);
            //transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotateSpeed);
            if (Vector2.Distance(transform.position, points[index]) <= 0.05f)
            {
                if (index < points.Count - 1) index++;
                else return;
            }
        }
        //trainRB.MovePosition(Vector2.Lerp(transform.position, point.position, speed + Time.deltaTime));
        //trainRB.AddForceAtPosition(Vector2.one * speed, point.position);
    }

    private void OnDisable()
    {
        points.Clear();
        gameObject.GetComponent<SpriteRenderer>().color = Color.white;
        transform.position = startPos;
        transform.rotation = Quaternion.identity;
    }

    void LookAt(Vector3 target)
    {
        Quaternion lookRotation = Quaternion.LookRotation(target - transform.position);
        float time = 0;
        while (time < 1)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, time);
            time += Time.deltaTime * rotateSpeed;
        }
    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Railroad"))
        {
            for(int i = 0; i < collision.gameObject.transform.childCount; i++)
            {
                if(Vector2.Distance(transform.position, collision.gameObject.transform.GetChild(i).position) > 0.5f) 
                    points.Add(collision.gameObject.transform.GetChild(i).position);
            }
        }
    }

}
