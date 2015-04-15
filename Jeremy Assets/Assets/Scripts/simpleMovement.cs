<<<<<<< HEAD
﻿using System.Collections;
using UnityEngine;

public class simpleMovement : MonoBehaviour
{
    #region Public Fields + Properties + Events + Delegates

    public bool move = true;
    public float speed = 1.5f;

    #endregion Public Fields + Properties + Events + Delegates

    #region Private Methods

    // Update is called once per frame
    private void Update()
    {
        ExtraCellularProperties myScript = (ExtraCellularProperties)GetComponent("ExtraCellularProperties");

        Debug.Log(myScript.allowMovement);

        if (Input.GetKey(KeyCode.LeftArrow) && myScript.allowMovement)
        {
            transform.position += Vector3.left * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.RightArrow) && myScript.allowMovement)
        {
            transform.position += Vector3.right * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.UpArrow) && myScript.allowMovement)
        {
            transform.position += Vector3.up * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.DownArrow) && myScript.allowMovement)
        {
            transform.position += Vector3.down * speed * Time.deltaTime;
        }
    }

    #endregion Private Methods
=======
﻿using System.Collections;
using UnityEngine;

public class simpleMovement : MonoBehaviour
{
    #region Public Fields + Properties + Events + Delegates

    public bool move = true;
    public float speed = 1.5f;

    #endregion Public Fields + Properties + Events + Delegates

    #region Private Methods

    // Update is called once per frame
    private void Update()
    {
        ExtraCellularProperties myScript = (ExtraCellularProperties)GetComponent("ExtraCellularProperties");

        Debug.Log(myScript.allowMovement);

        if (Input.GetKey(KeyCode.LeftArrow) && myScript.allowMovement)
        {
            transform.position += Vector3.left * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.RightArrow) && myScript.allowMovement)
        {
            transform.position += Vector3.right * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.UpArrow) && myScript.allowMovement)
        {
            transform.position += Vector3.up * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.DownArrow) && myScript.allowMovement)
        {
            transform.position += Vector3.down * speed * Time.deltaTime;
        }
    }

    #endregion Private Methods
>>>>>>> 22e297659be4c74786c7599e41b707305381885f
}