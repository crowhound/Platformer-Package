using UnityEngine;

namespace SF.SpawnModule
{
    /// <summary>
    /// Sets the attached game object as a checkpoint for the loaded level and can be used to invoke a <see cref="CheckPointEventTypes.ChangeCheckPoint"/> event when an allowable object triggers an OnTriggerEnter2D callback on the attached object.
    /// </summary>
    public class CheckPoint : MonoBehaviour, ICheckPoint
	{
		[SerializeField] public bool _doesActivateOnTriggerEnter2D = true;
		private void OnTriggerEnter2D(Collider2D collision)
		{
			if(!_doesActivateOnTriggerEnter2D)
				return;

			ActivateCheckPoint();
		}

        /// <summary>
        /// Invokes the checkpoint <see cref="CheckPointEventTypes.ChangeCheckPoint"/> event to tell the checkpoint manager to set a new checkpoint.
        /// </summary>
        public void ActivateCheckPoint()
		{
			CheckPointEvent.Trigger(CheckPointEventTypes.ChangeCheckPoint,this);
		}
	}
}
