using MilkShake;
using UnityEngine;

namespace VRH
{
    public class MilkshakeCameraShake : MonoBehaviour
    {
        public Shaker MyShaker;
        public ShakePreset ShakePreset;

        void Update()
        {
            // if(Input.GetKeyDown(KeyCode.F))
            // {
            //     RattleTheBrain();
            // }
        }

        public void RattleTheBrain()
        {
            MyShaker.Shake(ShakePreset);
        }
    }
}
