using System.Collections;
using UnityEngine.AI;
using UnityEngine;

namespace VRH
{
    public class Vault : MonoBehaviour
    {
        public Transform EndPos;
        NavMeshAgent _navAgent;
        Animator _anim;
        void Start()
        {
            _navAgent = GetComponent<NavMeshAgent>();
            _anim = GetComponent<Animator>();
            if(_anim == null)
            {
                Debug.Log("No animator in "+ GetType());
            }
        }
        void Update()
        {
            CheckOffMeshLinkStatus();
        }
        public void DoVault()
        {
            StartCoroutine(VaultRoutine(_navAgent, 5f));
        }
        IEnumerator VaultRoutine(NavMeshAgent agent, float duration)
        {
            
            OffMeshLinkData data = agent.currentOffMeshLinkData;
            Vector3 endPos = data.endPos * agent.baseOffset;//End of offmesh link

            float time = 0;
            while (time < duration)
            {
                _navAgent.transform.position = Vector3.MoveTowards(_navAgent.transform.position, EndPos.position/*endPos*/, /*time / duration*/(_navAgent.speed * 0.3f) * Time.deltaTime);
                

                time += Time.deltaTime;
                yield return null;
            }
            agent.CompleteOffMeshLink();
        }

        private void CheckOffMeshLinkStatus()
        {
            if (_navAgent.isOnOffMeshLink)
            {
                _navAgent.speed = _navAgent.speed * 0.02f;
            }
        }
    }
}