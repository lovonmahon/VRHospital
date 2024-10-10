using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VRH
{    
    public class DisableCanvasObjectOnGrab : MonoBehaviour, IDisable
    {
        // Start is called before the first frame update
        public void DisableGO()
        {
            this.gameObject.SetActive(false);
        }
    }
}
