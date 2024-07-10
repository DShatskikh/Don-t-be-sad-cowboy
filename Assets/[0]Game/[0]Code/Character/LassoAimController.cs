using UnityEngine;

namespace Game
{
    public class LassoAimController : Controller
    {
        private const float GrabDistance = 0.3f;

        private LassoAimView _aim;
        private LassoTarget[] _targets;
        private LassoTarget _nearestTarget;
        private float _nearestDistance = float.MaxValue;

        private readonly CharacterData _data;
        private readonly CharacterView _view;

        public LassoAimController(CharacterData data, CharacterView view)
        {
            _data = data;
            _view = view;
        }

        public override void OnEnter()
        {
            _aim = Object.Instantiate(GameData.AssetProvider.AimPrefab);
            _aim.transform.position = _data.transform.position;
            _view.LassoZoneActivate(true);

            _targets = Object.FindObjectsByType<LassoTarget>(FindObjectsInactive.Exclude, FindObjectsSortMode.None);
            SearchAndSelect(Vector2.zero);
        }

        public override void OnExit()
        {
            Object.Destroy(_aim.gameObject);
            _view.LassoZoneActivate(false);
            
            if (_nearestTarget)
                _nearestTarget.NotSelect();
        }

        public override void OnUpdate()
        {
            /*_aim.ColorGrab();
            
            if (IsLassoDiapason())
            {
                _view.LassoWhite();
            }
            else
            {
                _view.LassoRed();

                if (_nearestDistance < GrabDistance) 
                    _aim.NotColorGrab();
            }*/
        }

        public override void OnSlotIndexChanged(Vector2 direction)
        {
            if (_nearestTarget)
                _nearestTarget.NotSelect();

            SearchAndSelect(direction);
        }

        private void SearchAndSelect(Vector2 direction)
        {
            SearchNearestTarget(direction);

            if (!_nearestTarget)
                return;

            _aim.transform.position = _nearestTarget.transform.position;
            _nearestTarget.Select();
        }
        
        public override void OnLassoUp()
        {
            if (IsLassoDiapason()/* && _nearestDistance < GrabDistance*/)
            {
                _data.Lasso = Object.Instantiate(GameData.AssetProvider.LassoPrefab);
                _data.Lasso.Target = _nearestTarget;
                _nearestTarget.Grab();
            }

            GameData.CharacterStateMachine.TrySwitchState<ResearchCharacterState>();   
        }

        private void SearchNearestTarget(Vector2 direction)
        {
            var nearestTarget = _nearestTarget;
            var nearestDistance = float.MaxValue;

            if (_targets.Length != 0)
            {
                var startPoint = _nearestTarget
                    ? _nearestTarget.transform.position
                    : _data.transform.position;
                
                foreach (var target in _targets)
                {
                    var difference = target.transform.position - startPoint; 
                    var distance = Vector2.Distance(startPoint, target.transform.position);

                    if (target == nearestTarget)
                        continue;
                    
                    if (distance == 0)
                        continue;
                    
                    if ((direction.x > 0 && (difference.x < 0 || Mathf.Abs(difference.x) < Mathf.Abs(difference.y))) ||
                        (direction.x < 0 && (difference.x > 0 || Mathf.Abs(difference.x) < Mathf.Abs(difference.y))) ||
                        (direction.y > 0 && (difference.y < 0 || Mathf.Abs(difference.y) < Mathf.Abs(difference.x))) ||
                        (direction.y < 0 && (difference.y > 0 || Mathf.Abs(difference.y) < Mathf.Abs(difference.x)))
                        )
                        continue;

                    if (nearestDistance >= distance)
                    {
                        nearestTarget = target;
                        nearestDistance = distance;
                    }
                    
                    Debug.Log("" + target.gameObject.name + " direction: " + direction.x + " difference: " + difference.x + " startPoint: " + startPoint + " distance: " + distance + " nearestDistance: " + nearestDistance);

                }
            }

            _nearestTarget = nearestTarget;
            _nearestDistance = nearestDistance;
        }
        
        private bool IsLassoDiapason() => 
            _nearestTarget
            && Vector2.Distance(_data.transform.position, _nearestTarget.transform.position) < StringConstants.LassoSize;
    }
}