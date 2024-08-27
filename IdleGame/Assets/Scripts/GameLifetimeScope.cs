using Game.Character;
using VContainer;
using VContainer.Unity;

public class GameLifetimeScope : LifetimeScope
{
    protected override void Configure(IContainerBuilder builder)
    {
        PlayerConfigure(builder);
    }

    private void PlayerConfigure(IContainerBuilder builder)
    {
        builder.Register<Character>(Lifetime.Singleton);
    }
}
