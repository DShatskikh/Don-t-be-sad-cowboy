using UnityEngine;

namespace Game
{
    public class LassoAimController : Controller
    {
        private const float GrabDistance = 0.3f;
        
        private CharacterData _data;
        private Transform _aim;
        private Vector2 _aimPosition;
        private LassoTarget[] _targets;
        private LassoTarget _nearestTarget;
        private float _nearestDistance = float.MaxValue;

        public LassoAimController(CharacterData data, CharacterView view)
        {
            _data = data;
            _targets = Object.FindObjectsByType<LassoTarget>(FindObjectsInactive.Exclude, FindObjectsSortMode.None);
        }

        public override void OnEnter()
        {
            _aim = Object.Instantiate(GameData.AssetProvider.AimPrefab).transform;
            _aim.position = _data.transform.position;
        }

        public override void OnExit()
        {
            Object.Destroy(_aim.gameObject);
        }

        public override void OnUpdate()
        {
            SearchNearestTarget();

            if (_nearestTarget)
                _aim.position = _nearestDistance < GrabDistance ? _nearestTarget.transform.position : _aimPosition;
            else
                _aim.position = _aimPosition;
        }

        public override void OnAxisRaw(Vector2 direction)
        {
            _aimPosition += direction * Time.deltaTime * _data.Speed;
        }

        public override void OnLassoUp()
        {
            if (_nearestTarget && _nearestDistance < GrabDistance)
            {
                _data.Lasso = Object.Instantiate(GameData.AssetProvider.LassoPrefab);
                _data.Lasso.Target = _nearestTarget;
                _nearestTarget.Grab();
            }

            GameData.CharacterStateMachine.TrySwitchState<ResearchCharacterState>();   
        }

        private void SearchNearestTarget()
        {
            if (_targets.Length != 0)
            {
                _nearestTarget = _targets[0];
                _nearestDistance = Vector2.Distance(_nearestTarget.transform.position, _aimPosition);

                foreach (var target in _targets)
                {
                    var distance = Vector2.Distance(target.transform.position, _aimPosition);
                
                    if (_nearestDistance >= distance)
                    {
                        _nearestTarget = target;
                        _nearestDistance = distance;
                    }
                }
            }
        }
    }
}