<<<<<<< HEAD
﻿using System.Collections;
using UnityEngine;

public class KeyFunction : MonoBehaviour
    {
    // Use this for initialization 
    private void Start()
        {
        }

    private GameObject o = null;

    // Update is called once per frame 
    private void Update()
        {
        if (Input.GetKey(KeyCode.F))
            {
            o = GameObject.Find("_ExtraCellularProteinSignaller");

            Debug.Log("Found: " + o.name);
            }

        if (Input.GetKey(KeyCode.M))
            {
            ExtraCellularProperties myScript = o.GetComponent<ExtraCellularProperties>();
            Debug.Log("Changing movememnt to: " + !myScript.allowMovement);

            myScript.allowMovement = !myScript.allowMovement;
            }
        }
=======
﻿using System.Collections;
using UnityEngine;

public class KeyFunction : MonoBehaviour
    {
    // Use this for initialization 
    private void Start()
        {
        }

    private GameObject o = null;

    // Update is called once per frame 
    private void Update()
        {
        if (Input.GetKey(KeyCode.F))
            {
            o = GameObject.Find("_ExtraCellularProteinSignaller");

            Debug.Log("Found: " + o.name);
            }

        if (Input.GetKey(KeyCode.M))
            {
            ExtraCellularProperties myScript = o.GetComponent<ExtraCellularProperties>();
            Debug.Log("Changing movememnt to: " + !myScript.allowMovement);

            myScript.allowMovement = !myScript.allowMovement;
            }
        }
>>>>>>> 22e297659be4c74786c7599e41b707305381885f
    }