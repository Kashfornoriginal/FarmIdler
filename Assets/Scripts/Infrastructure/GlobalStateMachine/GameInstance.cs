using KasherOriginal.GlobalStateMachine;
using KasherOriginal.Factories.UIFactory;

public class GameInstance
{
    public GameInstance(IUIFactory uiFactory)
    {
        StateMachine = new StateMachine<GameInstance>(this, new BootstrapState(this),
            new SceneLoadingState(this, uiFactory),
            new MainMenuState(this, uiFactory),
            new GameLoadingState(this, uiFactory),
            new GameSetUpState(this),
            new GameplayState(this, uiFactory)
            );
        
        StateMachine.SwitchState<BootstrapState>();
    }

    public readonly StateMachine<GameInstance> StateMachine;
}
