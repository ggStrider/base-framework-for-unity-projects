using System.Collections.Generic;
using Cysharp.Threading.Tasks;

namespace ggStrider.Shared.Scripts.Runtime.Core.UI.Panels.Managers
{
    public class UIPanelManager : IUIPanelManager
    {
        private readonly Stack<IPanelUI> _stack = new();

        public async UniTask Open(IPanelUI panel)
        {
            _stack.Push(panel);
            await panel.Show();
        }

        public async UniTask CloseTop()
        {
            if (_stack.Count == 0) return;

            var panel = _stack.Pop();
            await panel.Hide();
        }

        public async UniTask CloseAll()
        {
            while (_stack.Count > 0)
            {
                var panel = _stack.Pop();
                await panel.Hide();
            }
        }
    }
}