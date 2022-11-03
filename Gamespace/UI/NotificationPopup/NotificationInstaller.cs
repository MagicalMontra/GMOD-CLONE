using UnityEngine;
using Zenject;

namespace Gamespace.UI
{
    [CreateAssetMenu(menuName = "Installer/Create NotificationInstaller", fileName = "NotificationInstaller", order = 0)]
    public class NotificationInstaller : ScriptableObjectInstaller<NotificationInstaller>
    {
        [SerializeField] private NotificationSettings _settings;
        
        public override void InstallBindings()
        {
            Container.Bind<NotificationPopupWorker>().AsSingle();
            Container.Bind<NotificationSettings>().FromInstance(_settings).AsSingle();
            Container.BindMemoryPool<NotificationPopup, NotificationPopup.Pool>().WithInitialSize(1).FromComponentInNewPrefab(_settings.popupPrefab).UnderTransformGroup("NotificationPopupPool");

            Container.DeclareSignal<NotificationRequestSignal>();

            Container.BindSignal<NotificationRequestSignal>().ToMethod<NotificationPopupWorker>(getter => getter.OnNotificationRequest).FromResolve();
        }
    }
}