using ggStrider.Shared.Scripts.Runtime.Features.Items;

namespace ggStrider.Shared.Scripts.Runtime.Core.Data.Services
{
    public interface IPlayerDataService
    {
        public bool Contains(GameItemSO item);
        public bool TryAdd(GameItemSO item, int amount, out int howMuchAdded);
    }
}