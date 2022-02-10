using UnityEngine;
using Views;

namespace Configs
{
    [CreateAssetMenu(fileName = "PlayerConfig", menuName = "App/Config/PlayerConfig", order = 1)]
    public class PlayerConfig: ScriptableObject
    {
        [SerializeField] private float fireRate;
        public float FireRate => fireRate;

        
        [SerializeField] private JetMissleView jetMisslePrefab;
        public JetMissleView JetMisslePrefab=> jetMisslePrefab;
        

        [SerializeField] private Vector3 jetMissleSpawnPoint;
        public Vector3 JetMissleSpawnPoint => jetMissleSpawnPoint;

        [SerializeField] private float playerSpeed;
        public float PlayerSpeed => playerSpeed;

        [SerializeField] private float inclineValue;
        public float InclineValue => inclineValue;

        [SerializeField] private float inclineTime;
        public float InclineTime => inclineTime;

    }
}
