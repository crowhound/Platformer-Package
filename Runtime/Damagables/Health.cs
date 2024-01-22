using UnityEngine;
using SF.CommandModule;
using SF.Events;
using SF.SpawnModule;

namespace SF
{
    public class Health : MonoBehaviour, IDamagable, EventListener<RespawnEvent>
    {
        public CheckPointManager SpawnPoint;

        public CommandController CommandController;
        public int CurrentHealth = 10;
        public int MaxHealth = 10;

        public void TakeDamage(int damage)
        {
            if (CommandController != null)
                CommandController.StartCommands();

            CurrentHealth -= damage;

            if (CurrentHealth < 0)
                CurrentHealth = 0;
            if(CurrentHealth == 0)
                Kill();
        }

        public void InstantKill()
        {
            CurrentHealth = 0;
            Kill();
		}

        public void Kill()
        {
            RespawnEvent.Trigger(RespawnEventTypes.PlayerRespawn);
        }

		public void OnEvent(RespawnEvent respawnEvent)
		{
			switch (respawnEvent.EventType) 
            {
                case RespawnEventTypes.PlayerRespawn:
                    Respawn();
                    break;
            }
		}
        private void Respawn()
        {
            if(SpawnPoint == null)
                return;
            transform.position = SpawnPoint.CurrentCheckPoint.transform.position;
        }

		private void OnEnable()
		{
            this.EventStartListening<RespawnEvent>();
		}
		private void OnDisable()
		{
			this.EventStopListening<RespawnEvent>();
		}
	}
}