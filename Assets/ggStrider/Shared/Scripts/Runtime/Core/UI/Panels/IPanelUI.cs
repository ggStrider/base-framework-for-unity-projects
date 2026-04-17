using Cysharp.Threading.Tasks;

namespace ggStrider.Shared.Scripts.Runtime.Core.UI.Panels
{
    public interface IPanelUI
    {
        bool IsVisible { get; }

        UniTask Show();
        UniTask Hide();
    }
}