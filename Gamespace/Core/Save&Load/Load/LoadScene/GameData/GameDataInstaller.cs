using UnityEngine;
using Zenject;

[CreateAssetMenu(fileName = "GameDataInstaller", menuName = "Installers/GameDataInstaller")]
public class GameDataInstaller : ScriptableObjectInstaller<GameDataInstaller>
{
    public GameData data_;
    public override void InstallBindings()
    {
        Container.Bind<GameData>().AsSingle();
    }
}