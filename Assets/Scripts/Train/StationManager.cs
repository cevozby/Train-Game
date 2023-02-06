using UnityEngine;

public class StationManager : MonoBehaviour
{
    MatchManager matchManager;
    // Start is called before the first frame update
    void Start()
    {
        matchManager = GameObject.Find("MatchManager").GetComponent<MatchManager>();//Catching MatcManager script
    }

    //When train enter the station, control matcing and set the train activeted
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Train"))
        {
            Color trainColor = collision.gameObject.GetComponent<SpriteRenderer>().color;
            Color stationColor = this.gameObject.GetComponent<SpriteRenderer>().color;
            //Destroy(collision.gameObject);
            collision.gameObject.SetActive(false);
            ScoreManager.totalMatch++;
            matchManager.MatchObjects(trainColor, stationColor);
        }
    }

}
