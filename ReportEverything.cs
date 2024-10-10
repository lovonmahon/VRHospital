using System;
using System.Collections;
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
        bool getAggressive;
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
            InfusionMachineOperation.incorrectInfustionSetting += AggressionNotifier;
            

            //positive actions
            PutOnMask.maskOn += PatientKnowledgePositive;
            HandSanitizer.useSanitizer += PatientKnowledgePositive;
            DialogueEffects.onPositiveDialogue += PatientKnowledgePositive;
            PutOnGloves.glovesOn += PatientKnowledgePositive;
            LightSwitch._lightsOff += PatientKnowledgePositive;
            GiveToPatient.onHappy += PatientKnowledgePositive;
            InfusionMachineOperation.correctInfusionSetting += PatientKnowledgePositive;
            TrashItems.onBioHazDisposal += PatientKnowledgePositive;
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
            InfusionMachineOperation.incorrectInfustionSetting += AggressionNotifier;

            //Positive actions
            PutOnMask.maskOn -= PatientKnowledgePositive;
            HandSanitizer.useSanitizer -= PatientKnowledgePositive;
            DialogueEffects.onPositiveDialogue -= PatientKnowledgePositive;
            PutOnGloves.glovesOn -= PatientKnowledgePositive;
            LightSwitch._lightsOff -= PatientKnowledgePositive;
            GiveToPatient.onHappy -= PatientKnowledgePositive;
            InfusionMachineOperation.correctInfusionSetting -= PatientKnowledgePositive;
            TrashItems.onBioHazDisposal -= PatientKnowledgePositive;
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
            _patientFaction.pad.Modify(-5, -5, 15, -5);

        }
        void AggressionNotifier()
        {
            getAggressive = true;
            //happiness, pleasure, arousal, dominance
            _patientFaction.pad.Modify(-100, -100, 100, 100);
            StartCoroutine(ResetAggression());
        }
        public bool InfusionPumpNotifyAIBrainCanAttack()
        {
            return getAggressive;
        }
        IEnumerator ResetAggression()
        {
            yield return new WaitForSeconds(15f);
            getAggressive = false;
        }
    }
}
