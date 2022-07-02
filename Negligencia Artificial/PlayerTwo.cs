using Core.Games;
using Core.Player;
using Core.Utils;
using UnityEngine;

namespace Teams.Negligencia_Artificial
{
    public class PlayerTwo : TeamPlayer
    {
        public override void OnUpdate()
        {
            //GoTo(FieldPosition.D3);
            var ballPosition = GetBallPosition();
            var directionToBall = GetDirectionTo(ballPosition);
            MoveBy(directionToBall);
        }

        public override void OnReachBall()
        {
            var rivalGoalPosition = GetRivalGoalPosition();
            var directionToRivaGoal = GetDirectionTo(rivalGoalPosition);
            ShootBall(directionToRivaGoal, ShootForce.High);
            
                ShootForce sf;
            ShootBall(GetDirectionTo(
                Utilities.HacerPase(
                    GetPosition(), GetTeamMatesInformation(), GetRivalGoalPosition(), out sf)),
                    sf);

        }


        public override void OnScoreBoardChanged(ScoreBoard scoreBoard)
        {

        }

        public override FieldPosition GetInitialPosition() => FieldPosition.C3;

        public override string GetPlayerDisplayName() => "Carlitos Tevez";
    }
}

