using System.Collections.Generic;
using UnityEngine;

public class SwitchManager : MonoBehaviour
{
    [SerializeField] List<GameObject> railRoads;
    int index;

    bool isBusy;

    Touch touch;
    // Start is called before the first frame update
    void Start()
    {
        index = 0;
    }

    // Update is called once per frame
    void Update()
    {
        ChangeRoad();
    }
    //Change the road with touching
    void ChangeRoad()
    {
        if ((Input.GetMouseButtonDown(0) || Input.touchCount > 0) && !isBusy)
        {
            touch = Input.GetTouch(0);
            //Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition); For windows
            Ray ray = Camera.main.ScreenPointToRay(touch.position);
            RaycastHit2D hit = Physics2D.GetRayIntersection(ray);
            if(touch.phase == TouchPhase.Began && hit.collider != null && hit.collider.gameObject.CompareTag("SwitchRoad") && hit.collider.gameObject == this.gameObject)
            {
                if (index < railRoads.Count - 1) index++;
                else index = 0;
                if(index!= 0)
                {
                    railRoads[index - 1].SetActive(false);
                    railRoads[index].SetActive(true);
                }
                else
                {
                    railRoads[railRoads.Count - 1].SetActive(false);
                    railRoads[index].SetActive(true);
                }
                
            }
        }
        
    }
    //If the train enter the road, return isBusy true
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Train")) isBusy = true;
    }
    //If the train exit the road, return isBusy false
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Train")) isBusy = false;
    }

}
