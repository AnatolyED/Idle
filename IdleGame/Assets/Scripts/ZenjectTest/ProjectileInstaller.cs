using UnityEngine;
using Zenject;

public class ProjectileInstaller : MonoInstaller
{
    [SerializeField]
    private TestService testService;

    public override void InstallBindings()
    {
        Container.Bind<TestService>().FromInstance(testService);
    }
}
