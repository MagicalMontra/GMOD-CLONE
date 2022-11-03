using UnityEngine;
using Zenject;

namespace Gamespace.Utilis
{
    [CreateAssetMenu(menuName = "Create UtilisInstaller", fileName = "UtilisInstaller", order = 0)]
    public class UtilisInstaller : ScriptableObjectInstaller<UtilisInstaller>
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<GizmoController>().AsSingle();
            Container.BindFactory<NonMonoDrawGizmo, NonMonoDrawGizmo.Factory>().FromFactory<NonMonoDrawGizMoFactory>();

            Container.DeclareSignal<GizmoRequestSignal>();
            
            Container.BindSignal<GizmoRequestSignal>().ToMethod<GizmoController>(c => c.OnGizmoRequest).FromResolve();
        }
    }
}