using Commands;
using Configs;
using Presenters;
using Signals;
using UnityEngine;
using Views;
using Zenject;

namespace Installers
{
    public class LevelInstaller : MonoInstaller
    {
        [SerializeField] private PlayerView playerView;
        
        public override void InstallBindings()
        {
            Debug.Log("Install bindings");
            
            SignalBusInstaller.Install(Container);

            //Configs
            Container.Bind<PlayerConfig>().FromScriptableObjectResource("Configs/PlayerConfig").AsSingle();

            // Views & Presenters
            Container.Bind<PlayerView>().FromInstance(playerView).AsSingle();
            Container.BindInterfacesAndSelfTo<PlayerPresenter>().AsSingle().NonLazy();
            Container.Bind<MainStartFromLevel>().AsSingle();
            
            //Signals
            Container.DeclareSignal<FirePressedSignal>();

            //Commands
            Container.BindInterfacesAndSelfTo<PlayerFireCommand>().AsSingle();
            
            Container.BindSignal<FirePressedSignal>()
                .ToMethod<PlayerFireCommand>(x => x.Execute).FromResolve();
        }
    }
}