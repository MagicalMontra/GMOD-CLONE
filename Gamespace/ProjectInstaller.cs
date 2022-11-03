using UnityEngine;
using Zenject;

[CreateAssetMenu(menuName = "Create ProjectInstaller", fileName = "ProjectInstaller", order = 0)]
public class ProjectInstaller : ScriptableObjectInstaller<ProjectInstaller>
{
    public override void InstallBindings()
    {
        SignalBusInstaller.Install(Container);
    }
}
