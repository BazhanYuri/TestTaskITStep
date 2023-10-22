using System.Collections;
using System.Collections.Generic;
using Zenject;
public class UIBuilder : IUIBuilder, IInitializable
{
    private SpeedChangeViewFactory _speedChangeViewFactory;

    public ISpeedChangeView SpeedChangeView { get; private set; }

    [Inject]
    public void Construct(SpeedChangeViewFactory speedChangeViewFactory)
    {
        _speedChangeViewFactory = speedChangeViewFactory;
    }

    public ISpeedChangeView CreateSpeedChangeView()
    {
        SpeedChangeView = _speedChangeViewFactory.Create();
        return SpeedChangeView;
    }

    public void Initialize()
    {
        CreateSpeedChangeView();
    }
}
public class SpeedChangeViewFactory : PlaceholderFactory<SpeedChangeView>
{

}
