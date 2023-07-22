using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] GameObject potatoPrefab;
    [SerializeField] GameObject eggplantPrefab;
    [SerializeField] GameObject carrotPrefab;
    [SerializeField] GameObject woodPrefab;
    [SerializeField] Transform startingPoint;

    public bool IsLevelOn = false;

    List<GameObject> spawnObjects = new List<GameObject>();
    List<float> sizes = new List<float>();
    List<float> bornXAngles = new List<float>() { 90f, 90f, 0f };

    int _minSequentialVegetables = 3;
    float _woodProbability = 0.5f;
    int _currentSequentialVegetables = 0;

    void Start()
    {
        if (potatoPrefab == null)
        {
            Debug.LogError("Potato Prefab is not set");
        }
        if (eggplantPrefab == null)
        {
            Debug.LogError("Eggplant Prefab is not set");
        }
        if (carrotPrefab == null)
        {
            Debug.LogError("Carrot Prefab is not set");
        }
        if (startingPoint == null)
        {
            Debug.LogError("Starting Point is not set");
        }
        if (woodPrefab == null)
        {
            Debug.LogError("Wood Prafab Point is not set");
        }
        spawnObjects.Add(potatoPrefab);
        spawnObjects.Add(eggplantPrefab);
        spawnObjects.Add(carrotPrefab);
        spawnObjects.Add(woodPrefab);
        sizes.Add(Vector3.Scale(potatoPrefab.GetComponent<BoxCollider>().size, potatoPrefab.transform.localScale).y);
        sizes.Add(Vector3.Scale(eggplantPrefab.GetComponent<BoxCollider>().size, eggplantPrefab.transform.localScale).y);
        sizes.Add(Vector3.Scale(carrotPrefab.GetComponent<BoxCollider>().size, carrotPrefab.transform.localScale).z);
        sizes.Add(Vector3.Scale(woodPrefab.GetComponent<BoxCollider>().size, woodPrefab.transform.localScale).z);
        FillOnStart();
    }

    void Update()
    {
        
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("vegetables") || other.CompareTag("wood"))
        {
            SpawnObject(transform.position.z);
        }
    }

    void FillOnStart()
    {
        Vector3 currentSpawnPoint = startingPoint.position;
        while (currentSpawnPoint.z < transform.position.z)
        {
            int choice = SpawnObject(currentSpawnPoint.z);
            currentSpawnPoint.z += sizes[choice];
        }
    }

    int SpawnObject(float zPos)
    {
        Vector3 spawnPos = transform.position;
        spawnPos.z = zPos;
        if ((_currentSequentialVegetables >= _minSequentialVegetables) && (Random.Range(0f, 1f) < _woodProbability))
        {
            Instantiate(woodPrefab, Vector3.Scale(spawnPos, Vector3.forward), Quaternion.identity);
            _currentSequentialVegetables = 0;
            return 3;
        }
        int choice = Random.Range(0, 3);
        Instantiate(spawnObjects[choice], spawnPos, Quaternion.Euler(bornXAngles[choice], 0, 0));
        _currentSequentialVegetables += 1;
        return choice;
    }
}
