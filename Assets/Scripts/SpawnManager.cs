using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Colors { Red, Orange, Yellow, Green, Blue, Purple}
public class SpawnManager : MonoBehaviour
{
    [SerializeField] GameObject train;

    bool isReady = true;

    [SerializeField] float cooldownTimer, spawnTimer;

    [SerializeField] string parentObjectName;

    [SerializeField] List<Color> trainColors;

    Colors colors;

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
        
        if (spawnTimer > 0f) SpawnTrain();
        else Destroy(this);
        spawnTimer -= Time.deltaTime;
    }

    void SpawnTrain()
    {
        if (isReady)
        {
            isReady = false;
            Instantiate(train, transform.position, Quaternion.identity, GameObject.Find(parentObjectName).transform).
                GetComponent<SpriteRenderer>().color = colorManager.ChangeTrainColor();
            //colorManager.ChangeTrainColor(train.GetComponent<SpriteRenderer>());
            StartCoroutine(Cooldown());
        }
    }

    IEnumerator Cooldown()
    {
        yield return new WaitForSeconds(cooldownTimer);
        isReady = true;
    }

}
