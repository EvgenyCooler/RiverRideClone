using System;
using System.Collections.Generic;
using System.Linq;
using Configs;
using DG.Tweening;
using Signals;
using UnityEngine;
using Views;
using Zenject;
using Object = UnityEngine.Object;

namespace Presenters
{
    public class PlayerPresenter : IInitializable, IDisposable, ITickable
    {
        [SerializeField] private SignalBus signalBus;
        [SerializeField] private PlayerConfig playerConfig;
        [SerializeField] private PlayerView playerView;
        
        // Fire section
        private List<JetMissleView> jetMisslesPool = new List<JetMissleView>();
        private float fireRateTimer = 0f;
        
        // Transform section
        
        
        public PlayerPresenter(SignalBus signalBus, PlayerView playerView, PlayerConfig playerConfig)
        {
            this.signalBus = signalBus;
            this.playerConfig = playerConfig;
            this.playerView = playerView;
        }
        
        public void Initialize()
        {
            Debug.Log("Player presenter initialize");
            playerView.OnFirePressed += OnFirePressedHandler;
            fireRateTimer = 0;
        }
        
        public void Dispose()
        {
            playerView.OnFirePressed -= OnFirePressedHandler;
        }

        public void Tick()
        {
            if(fireRateTimer <= 0)
                return;

            fireRateTimer -= Time.deltaTime;
        }

        #region Handlers
        private void OnFirePressedHandler()
        {
            Debug.Log("Fire pressed signal on player presenter");
            
            if (fireRateTimer > 0)
                return;
            
            signalBus.Fire<FirePressedSignal>();
            SpawnMissle();
            fireRateTimer = playerConfig.FireRate;
        }
        #endregion
        
        #region Move
       

        #endregion

        #region Fire
        private void SpawnMissle()
        {
            JetMissleView missle = jetMisslesPool.FirstOrDefault(x => !x.InUse);

            if (missle == null)
            {
                missle = Object.Instantiate<JetMissleView>(
                    playerConfig.JetMisslePrefab, 
                    playerView.transform.position + playerConfig.JetMissleSpawnPoint, 
                    Quaternion.identity);
                
                jetMisslesPool.Add(missle);
            }
            else
            {
                missle.gameObject.SetActive(false);
                missle.transform.position = playerView.transform.position + playerConfig.JetMissleSpawnPoint;
            }

            missle.InUse = true;
            missle.name = "Missle";
            missle.gameObject.SetActive(true);
            missle.transform.DOMove(new Vector3(0, 0, 70), 2f).SetEase(Ease.InSine).OnComplete(() =>
            {
                missle.InUse = false;
            });

        }
        #endregion
        
        
        
    }
}
