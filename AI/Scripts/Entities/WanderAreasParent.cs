using UnityEngine;

namespace VRH
{
    public class WanderAreasParent : MonoBehaviour
    {
        public AreaOfInterest[] areas;
        void Awake()
        {
            areas = GetComponentsInChildren<AreaOfInterest>();
        }

        public AreaOfInterest GetRandomArea()
        {
            return areas[Random.Range(0, areas.Length -1)];
        }
    }
}
