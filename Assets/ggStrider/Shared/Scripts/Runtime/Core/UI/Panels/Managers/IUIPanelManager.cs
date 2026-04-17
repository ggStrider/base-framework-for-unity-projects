using Cysharp.Threading.Tasks;

namespace ggStrider.Shared.Scripts.Runtime.Core.UI.Panels.Managers
{
    public interface IUIPanelManager
    {
        public UniTask Open(IPanelUI panel);
        public UniTask CloseAll();
        public UniTask CloseTop();
    }
}