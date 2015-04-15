<<<<<<< HEAD
﻿using System.Collections;
using UnityEngine;

public class ExtraCellularProperties : MonoBehaviour
{
    #region Public Fields + Properties + Events + Delegates

    public bool allowMovement = true;
    public bool isActive = true;

    #endregion Public Fields + Properties + Events + Delegates
=======
﻿using System.Collections;
using UnityEngine;

public class ExtraCellularProperties : MonoBehaviour
{
    #region Public Fields + Properties + Events + Delegates + Enums

    public bool allowMovement = true;

    public bool isActive = true;

    #endregion Public Fields + Properties + Events + Delegates + Enums

    #region Private Methods

    private void FixedUpdate()
    {
        if (isActive)
        {
            Component go = this.GetComponent("Extracellular Signal Body");
            go.GetComponent<Renderer>().material.color = Color.blue;
        }
        else
        {
            Component go = this.GetComponent("Extracellular Signal Body");
            go.GetComponent<Renderer>().material.color = Color.red;
        }
    }

    #endregion Private Methods
>>>>>>> 22e297659be4c74786c7599e41b707305381885f
}