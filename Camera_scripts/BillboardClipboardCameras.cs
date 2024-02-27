using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VRH
{    
    public class BillboardClipboardCameras : MonoBehaviour
    {
        public enum ViewCams
        {
            Billboard,
            Clipboard 
        }
        BillboardCam billBoardCam;
        ClipboardCam clipBoardCam;
        bool alreadyViewingFormulas;
        public ViewCams cams;
        public GameObject openUI;
        public GameObject closeUI;
        bool view;
        void Start()
        {
            openUI.SetActive(false);
            closeUI.SetActive(false);
            billBoardCam = GameObject.FindObjectOfType<BillboardCam>();
            clipBoardCam = GameObject.FindObjectOfType<ClipboardCam>();
            billBoardCam.gameObject.SetActive(false);
            clipBoardCam.gameObject.SetActive(false);
        }

        void Update()
        {
            #region android input handling
            #if UNITY_ANDROID
                if(OVRInput.Get(OVRInput.Button.Three) && alreadyViewingFormulas)
                {
                    InspectFormulaView();
                }
                if(OVRInput.Get(OVRInput.Button.Three) && !alreadyViewingFormulas)
                {
                    CloseFormulaView();
                }
            #endif
            #endregion
            #region unity editor input handling
            #if UNITY_EDITOR
                // if(Input.GetKey(KeyCode.X) && !alreadyViewingFormulas)
                // {
                //     InspectFormulaView();
                // }
                // else if(Input.GetKey(KeyCode.X) && alreadyViewingFormulas)
                // {
                //     CloseFormulaView();
                // }
            #endif
            #endregion
            SwitchToFocusCam();
        }
        void OnTriggerStay(Collider other)
        {
            if(other.GetComponent<PlayerComponent>())
            {
                openUI.SetActive(true);
                closeUI.SetActive(false);
                if(Input.GetKey(KeyCode.X) && !alreadyViewingFormulas)
                {
                    alreadyViewingFormulas = true;
                    InspectFormulaView();
                }
                else if(Input.GetKey(KeyCode.X) && alreadyViewingFormulas)
                {
                    alreadyViewingFormulas = false;
                    CloseFormulaView();
                }
            }
        }
        void OnTriggerExit(Collider other)
        {
            if(other.GetComponent<PlayerComponent>())
            {
                alreadyViewingFormulas = false;
                closeUI.SetActive(false);
                openUI.SetActive(false);
            }
        }
        void SwitchToFocusCam()
        {
            if (view)
            {
                switch (cams)
                {
                    case ViewCams.Billboard:
                        billBoardCam.gameObject.SetActive(true);
                        closeUI.SetActive(true);
                        openUI.SetActive(false);
                        break;
                    case ViewCams.Clipboard:
                        clipBoardCam.gameObject.SetActive(true);
                        closeUI.SetActive(true);
                        openUI.SetActive(false);
                        break;
                    default:
                        Debug.LogError("Select the appropriate rendering camera");
                        break;
                }
            }
        }
        public void InspectFormulaView()
        {
            view = true;
            
        }
        public void CloseFormulaView()
        {
            view = false;
            if(!view)
            {
                switch(cams)
                {
                    case ViewCams.Billboard: 
                        billBoardCam.gameObject.SetActive(false);
                        break;
                    case ViewCams.Clipboard: 
                        clipBoardCam.gameObject.SetActive(false);
                        break;    
                }
            }
        }
    }
}
