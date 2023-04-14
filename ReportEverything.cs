using System;
using PixelCrushers.LoveHate;
using UnityEngine;

namespace VRH
{
//Every comfort/discomfort caused to patient reported to all subscribers
    public class ReportEverything : MonoBehaviour
    {
        GameObject patient;
        
        void Start()
        {
            patient = GameObject.Find("Patient");
            if(patient ==  null) return;
        }

        void OnEnable()
        {
            //negative actions
            GiveInjection.pain += PatientKnowledgeNegative;
            TakeTemperature.takeTemp += PatientKnowledgeNegative;

            //positive actions
            PutOnMask.maskOn += PatientKnowledgePositive;
            HandSanitizer.useSanitizer += PatientKnowledgePositive;
        }
        void OnDisable()
        {
            //Negative actions
            GiveInjection.pain -= PatientKnowledgeNegative;
            TakeTemperature.takeTemp -= PatientKnowledgeNegative;

            //Positive actions
            PutOnMask.maskOn -= PatientKnowledgePositive;
            HandSanitizer.useSanitizer -= PatientKnowledgePositive;
        }

        void PatientKnowledgePositive()
        {
            GetComponent<DeedReporter>().ReportDeed("Comfort", patient.GetComponent<FactionMember>());
        }
        void PatientKnowledgeNegative()
        {
            GetComponent<DeedReporter>().ReportDeed("Discomfort", patient.GetComponent<FactionMember>());
        }
    }
}
