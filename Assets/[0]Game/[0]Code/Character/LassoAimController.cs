using UnityEngine;

namespace Game
{
    public class LassoAimController : Controller
    {
        private const float GrabDistance = 0.3f;

        private LassoAimView _aim;
        private Vector2 _aimPosition;
        private LassoTarget[] _targets;
        private LassoTarget _nearestTarget;
        private float _nearestDistance = float.MaxValue;

        private readonly CharacterData _data;
        private readonly CharacterView _view;

        public LassoAimController(CharacterData data, CharacterView view)
        {
            _data = data;
            _view = view;
            _targets = Object.FindObjectsByType<LassoTarget>(FindObjectsInactive.Exclude, FindObjectsSortMode.None);
        }

        public override void OnEnter()
        {
            _aim = Object.Instantiate(GameData.AssetProvider.AimPrefab);
            _aim.transform.position = _data.transform.position;
            _aimPosition = _aim.transform.position;
            _view.LassoZoneActivate(true);
        }

        public override void OnExit()
        {
            Object.Destroy(_aim.gameObject);
            _view.LassoZoneActivate(false);
        }

        public override void OnUpdate()
        {
            SearchNearestTarget();

            _aim.ColorGrab();
            
            if (IsLassoDiapason())
            {
                _view.LassoWhite();
            }
            else
            {
                _view.LassoRed();

                if (_nearestDistance < GrabDistance) 
                    _aim.NotColorGrab();
            }
        }

        public override void OnAxisRaw(Vector2 direction)
        {
            _aimPosition += direction * Time.deltaTime * _data.Speed;
            
            if (_nearestTarget)
                _aim.transform.position = _nearestDistance < GrabDistance ? _nearestTarget.transform.position.AddY(_nearestTarget.DifferenceY) : _aimPosition;
            else
                _aim.transform.position = _aimPosition;
        }

        public override void OnLassoUp()
        {
            if (IsLassoDiapason() && _nearestDistance < GrabDistance)
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
        
        private bool IsLassoDiapason() => 
            _nearestTarget
            && Vector2.Distance(_data.transform.position, _aimPosition) < StringConstants.LassoSize;
    }
}