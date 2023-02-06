using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] float distance;
    [SerializeField] float speed;

    Vector3 target;

    public static bool isFinishMove;

    private void Start()
    {
        isFinishMove = false;
        target = new Vector3(transform.position.x + distance, transform.position.y, transform.position.z);
    }

    private void FixedUpdate()
    {
        //Go to the target at the end of the game and return true when you reach that point
        if (GameController.isEnd)
        {
            transform.position = Vector3.MoveTowards(transform.position, target, speed);
            if (Vector2.Distance(transform.position, target) <= 0.1f) isFinishMove = true;
        }
    }
}
