using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchManager : MonoBehaviour
{
    [SerializeField] List<GameObject> railRoads;
    int index;

    bool isBusy;
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

    void ChangeRoad()
    {
        if (Input.GetMouseButtonDown(0) && !isBusy)
        {
            Debug.Log("Týkladýn");
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit = Physics2D.GetRayIntersection(ray);
            if(hit.collider != null && (hit.collider.gameObject.CompareTag("SwitchRoad") ||
                hit.collider.transform.parent.parent.gameObject.CompareTag("SwitchRoad")))
            {
                Debug.Log("Ray vurdu");
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Train")) isBusy = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Train")) isBusy = false;
    }

}
