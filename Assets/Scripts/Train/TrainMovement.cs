using System.Collections.Generic;
using UnityEngine;

public class TrainMovement : MonoBehaviour
{
    [SerializeField] Vector3 startPoint;
    public List<Vector3> points;
    [SerializeField] float speed, rotateSpeed, rotationModifier;
    int index;

    Vector3 startPos;//Start position of train

    private void OnEnable()
    {
        index = 0;
        startPoint = GameObject.Find("StartPoint").GetComponent<Transform>().position;
    }

    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
    }

    void FixedUpdate()
    {
        TrainMove();
    }
    //Reset all values when the train activated false
    private void OnDisable()
    {
        points.Clear();
        gameObject.GetComponent<SpriteRenderer>().color = Color.white;
        transform.position = startPos;
        transform.rotation = Quaternion.identity;
    }
    //Set train move points
    void TrainMove()
    {
        if (points.Count == 0)
        {
            transform.position = Vector2.MoveTowards(transform.position, startPoint, speed);
        }
        else
        {
            transform.position = Vector2.MoveTowards(transform.position, points[index], speed);
            SetRotation(points[index]);
            if (Vector2.Distance(transform.position, points[index]) <= 0.05f)
            {
                if (index < points.Count - 1) index++;
                else return;
            }
        }
    }
    //Set the train rotation
    void SetRotation(Vector3 target)
    {
        Vector3 vectorToTarget = target - transform.position;
        float angle = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg - rotationModifier;
        Quaternion toRotation = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, toRotation, rotateSpeed);
    }


    //Get the points when train enter the road
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
