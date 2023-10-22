public interface IUIBuilder
{
    public ISpeedChangeView SpeedChangeView { get; }
    public ISpeedChangeView CreateSpeedChangeView();
}
