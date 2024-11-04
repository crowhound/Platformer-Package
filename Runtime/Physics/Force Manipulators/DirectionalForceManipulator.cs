using SF.Characters.Controllers;

using UnityEngine;

namespace SF
{

    public class DirectionalForceManipulator : MonoBehaviour, IForceManipulator
    {
        public Vector2 Force;
        public ContactFilter2D ContactFilter;
        
        [Header("Animations")]
        [SerializeField] private bool _hasOneShotAnimation;
        [SerializeField] private string _animationName;
        private Animator _animator;

        private void Awake()
        {
            if(_hasOneShotAnimation)
                _animator = GetComponent<Animator>();
        }

        public void OnTriggerEnter2D(Collider2D other)
        {
            if((ContactFilter.layerMask & (1 << other.gameObject.layer)) == 0)
                return;

            if(other.TryGetComponent(out IForceReciever forceReciever) )
            {
                ExtertForce(forceReciever, Force);
            }
        }

        public void ExtertForce(IForceReciever forceReciever, Vector2 force)
        {
            if(_hasOneShotAnimation && _animator != null)
            {
                _animator.Play("Adding Force",0);
            }
            forceReciever.SetExternalVelocity(force);
        }
    }
}