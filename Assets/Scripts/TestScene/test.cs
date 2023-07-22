using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{
    [SerializeField] GameObject potato;
    [SerializeField] GameObject eggplant;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            eggplant.SetActive(true);
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            potato.SetActive(true);
        }
    }
}
