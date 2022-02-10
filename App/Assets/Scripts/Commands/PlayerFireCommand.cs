using Signals;
using UnityEngine;

namespace Commands
{
    public class PlayerFireCommand : Command
    {
        
        public void Execute(FirePressedSignal firePressedSignal)
        {
            Debug.Log("Fire pressed!");        
        }
    }
}
