using System;
using ggStrider.Shared.Scripts.Runtime.Core.Data.Services;
using ggStrider.Shared.Scripts.Runtime.Features.Interactions.ByButton.Base;
using ggStrider.Shared.Scripts.Runtime.Features.Items;
using UnityEngine;
using Zenject;

namespace ggStrider.Shared.Scripts.Runtime.Features.Interactions.ByButton.Concrete
{
    public class InteractAddItem : BaseMonoInteract
    {
        [SerializeField] private GameItemSO _gameItemToAdd;
        [SerializeField] private int _amountToAdd = 1;

        [Space]
        [SerializeField] private GameObject _gameObjectToDestroyAfterAdded;

        private int _remainingToAdd = 0;
        private IPlayerDataService _playerDataService;

        [Inject]
        private void Construct(IPlayerDataService playerDataService)
        {
            _playerDataService = playerDataService;
        }

        private void OnEnable()
        {
            _remainingToAdd = _amountToAdd;
        }

        public override InteractResults OnInteract(InteractContext context)
        {
            if (_playerDataService.TryAdd(_gameItemToAdd, _remainingToAdd, out var howMuchAdded))
            {
                Destroy(_gameObjectToDestroyAfterAdded);
                return InteractResults.Success;
            }

            _remainingToAdd -= howMuchAdded;
            return InteractResults.Failed;
        }
    }
}