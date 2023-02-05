using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SpawnManager : MonoBehaviour
{
    //[SerializeField] GameObject train;
    [SerializeField] List<GameObject> trains;

    bool isReady = true;

    [SerializeField] float cooldownTimer;

    [SerializeField] string parentObjectName;

    ColorManager colorManager;

    // Start is called before the first frame update
    void Start()
    {
        new GameObject(parentObjectName);
        colorManager = GameObject.Find("ColorManager").GetComponent<ColorManager>();
    }

    // Update is called once per frame
    void Update()
    {
        SpawnControl();
    }

    void SpawnControl()
    {
        
        if (GameController.isPlayable) SpawnTrain();
        //else Destroy(this);
    }

    void SpawnTrain()
    {
        if (isReady)
        {
            isReady = false;
            trains[0].SetActive(true);
            trains[0].GetComponent<SpriteRenderer>().color = colorManager.ChangeTrainColor();
            GameObject tempTrain = trains[0];
            trains.RemoveAt(0);
            trains.Add(tempTrain);
            GameController.trainCount++;
            //Instantiate(train, transform.position, Quaternion.identity, GameObject.Find(parentObjectName).transform).
            //    GetComponent<SpriteRenderer>().color = colorManager.ChangeTrainColor();
            StartCoroutine(Cooldown());
        }
    }

    IEnumerator Cooldown()
    {
        yield return new WaitForSeconds(cooldownTimer);
        isReady = true;
    }

}
