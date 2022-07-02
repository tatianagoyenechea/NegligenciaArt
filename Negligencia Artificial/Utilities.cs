using System.Collections.Generic;
using Core.Games;
using Core.Player;
using UnityEngine;
namespace Teams.Negligencia_Artificial
{
    public static class Utilities
    {
        public static Vector3 HacerPase(Vector3 position, List<PlayerData> mates, Vector3 fallback, out ShootForce sf)
        {
            RaycastHit hit;


            if (Physics.Linecast(position, mates[1].Position, out hit)
                && hit.collider.gameObject.transform.position == mates[1].Position)
            {
                sf = ShootForce.Medium;
                return mates[1].Position;
            }
            else if (Physics.Linecast(position, mates[0].Position, out hit)
               && hit.collider.gameObject.transform.position == mates[0].Position)
            {
                sf = ShootForce.Medium;
                return mates[0].Position;
            }
            else
            {
                sf = ShootForce.High;
                return fallback;
            }
        }
    }
}