using UnityEngine;

namespace SF
{
	public enum CollisionEventTypes 
	{ 
		OnTriggerEnter2D,
		OnTriggerExit2D,
	}

	public class ZoneKill : MonoBehaviour
    {
		public CollisionEventTypes CollisionEvent;

		public void OnTriggerEnter2D(Collider2D collider2D)
		{
			if(CollisionEvent != CollisionEventTypes.OnTriggerEnter2D)
				return;

			if(collider2D.TryGetComponent(out IDamagable damageable))
			{
				damageable.InstantKill();
			}
		}

		public void OnTriggerExit2D(Collider2D collider2D)
		{
			if(CollisionEvent != CollisionEventTypes.OnTriggerExit2D)
				return;

			if(collider2D.TryGetComponent(out IDamagable damageable))
			{
				damageable.InstantKill();
			}
		}
	}
}
