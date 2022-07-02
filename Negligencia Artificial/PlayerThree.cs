using Core.Games;
using Core.Player;
using Core.Utils;
using UnityEngine;

namespace Teams.Negligencia_Artificial
{
    public class PlayerThree : TeamPlayer
    {
        public override void OnUpdate()
        {   
            
            var ballPosition = GetBallPosition();
            var directionToBall = GetDirectionTo(ballPosition);
            MoveBy(directionToBall);
        }

        public override void OnReachBall()
       {
            //Get teammates position and check if oponents are in the way
            //under this circustance, make the goal keeper shoot to an empty place
            //If there is no empty place, shoot random or away max force
            ShootForce sf;
            ShootBall(GetDirectionTo(
                Utilities.HacerPase(
                    GetPosition(), GetTeamMatesInformation(), GetRivalGoalPosition(), out sf)), 
                    sf);
        }

        public override void OnScoreBoardChanged(ScoreBoard scoreBoard)
        {

        }

        public override FieldPosition GetInitialPosition() => FieldPosition.C2;

        public override string GetPlayerDisplayName() => "Tata Martino";
    }
}