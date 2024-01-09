using System;
using PixelCrushers.LoveHate;
using UnityEngine;

//attach to Game Manager

namespace VRH
{
//Every comfort/discomfort caused to patient reported to all subscribers
    public class ReportEverything : MonoBehaviour
    {
        GameObject _patient;
        GameObject _player;
        DeedReporter _deed;
        FactionMember _patientFaction;
        void Start()
        {
            _patient = GameObject.Find("Patient");
            _player = GameObject.FindWithTag("Player");
            if(_patient ==  null) return;
            if(_player == null) return;
            _deed = _player.GetComponent<DeedReporter>();
            _patientFaction = _patient.GetComponent<FactionMember>();
        }
        void OnEnable()
        {
            //negative actions
            GiveInjection.pain += PatientKnowledgeNegative;
            TakeTemperature.takeTemp += PatientKnowledgeNegative;
            RandomDisorder.randomDisorder += PatientKnowledgeNegative;
            DialogueEffects.onNegativeDialogue += PatientKnowledgeNegative;
            LightSwitch._lightsOn += PatientKnowledgeNegative;
            InfusionMachineOperation.incorrectInfustionSetting += PatientKnowledgeNegative;
            

            //positive actions
            PutOnMask.maskOn += PatientKnowledgePositive;
            HandSanitizer.useSanitizer += PatientKnowledgePositive;
            DialogueEffects.onPositiveDialogue += PatientKnowledgePositive;
            PutOnGloves.glovesOn += PatientKnowledgePositive;
            LightSwitch._lightsOff += PatientKnowledgePositive;
            GiveToPatient.onHappy += PatientKnowledgePositive;
            InfusionMachineOperation.correctInfusionSetting += PatientKnowledgePositive;
        }
        void OnDisable()
        {
            //Negative actions
            GiveInjection.pain -= PatientKnowledgeNegative;
            TakeTemperature.takeTemp -= PatientKnowledgeNegative;
            RandomDisorder.randomDisorder -= PatientKnowledgeNegative;
            DialogueEffects.onNegativeDialogue -= PatientKnowledgeNegative;
            LightSwitch._lightsOn -= PatientKnowledgeNegative;
            InfusionMachineOperation.incorrectInfustionSetting -= PatientKnowledgeNegative;

            //Positive actions
            PutOnMask.maskOn -= PatientKnowledgePositive;
            HandSanitizer.useSanitizer -= PatientKnowledgePositive;
            DialogueEffects.onPositiveDialogue -= PatientKnowledgePositive;
            PutOnGloves.glovesOn -= PatientKnowledgePositive;
            LightSwitch._lightsOff -= PatientKnowledgePositive;
            GiveToPatient.onHappy -= PatientKnowledgePositive;
            InfusionMachineOperation.correctInfusionSetting -= PatientKnowledgePositive;
        }

        void PatientKnowledgePositive()
        {
            _deed.ReportDeed("Comfort", _patientFaction);
            // _patientFaction.pad.Modify(+10, +10, -10, +10);
        }
        void PatientKnowledgeNegative()
        {
            // _deed.ReportDeed("Hurt", _patientFaction);
            //happiness, pleasure, arousal, dominance
            _patientFaction.pad.Modify(-20, -20, 20, 25);

        }
    }
}
