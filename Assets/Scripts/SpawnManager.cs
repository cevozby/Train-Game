using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] GameObject train;

    bool isReady = true;

    [SerializeField] float cooldownTimer, spawnTimer;

    [SerializeField] string parentObjectName;

    // Start is called before the first frame update
    void Start()
    {
        new GameObject(parentObjectName);
        
    }

    // Update is called once per frame
    void Update()
    {
        SpawnControl();
    }

    void SpawnControl()
    {
        spawnTimer -= Time.deltaTime;

        if (spawnTimer > 0f) SpawnTrain();
        else Destroy(this);
    }

    void SpawnTrain()
    {
        if (isReady)
        {
            isReady = false;
            Instantiate(train, transform.position, Quaternion.identity, GameObject.Find(parentObjectName).transform);
            StartCoroutine(Cooldown());
        }
    }

    IEnumerator Cooldown()
    {
        yield return new WaitForSeconds(cooldownTimer);
        isReady = true;
    }

}
