using Core.Games;
using Core.Player;
using Core.Utils;
using UnityEngine;
namespace Teams.Negligencia_Artificial
{
    public class Goalkeeper : TeamPlayer
    {
        private const float minimumDistanceToGoal = 10;
        public override void OnUpdate() //Lo que hace el jugador cada vez que se actualiza;
        {

            var startingPoint = GetPosition();
            var direction = GetDirectionTo(GetRivalGoalPosition());
            var point = GetBallPosition();

            Ray ray = new Ray(startingPoint, Vector3.Normalize(direction));
            float distance = Vector3.Cross(ray.direction, point - ray.origin).magnitude;


            var ballPosition = GetBallPosition();

            if (BallIsNearGoal(ballPosition))
            {
                MoveBy(GetDirectionTo(ballPosition));
            }
            else
            {
                GoTo(FieldPosition.A2);
            }
            if (GetRivalScore() > GetMyScore())
            {
                GoTo(FieldPosition.A2);
            }


            bool BallIsNearGoal(Vector3 ballPosition) =>
                  Vector3.Distance(ballPosition, GetMyGoalPosition()) < minimumDistanceToGoal;
        }


        public override void OnReachBall() // Cada vez que el jugador toca la pelota;
        {
            //ShootBall(GetDirectionTo(GetRivalGoalPosition()), ShootForce.High);
            ShootForce sf;
            ShootBall(GetDirectionTo(
                Utilities.HacerPase(
                    GetPosition(), GetTeamMatesInformation(), GetRivalGoalPosition(), out sf)),
                    sf);

        }



        public override void OnScoreBoardChanged(ScoreBoard scoreBoard)
        {
            if (scoreBoard.My < scoreBoard.Rival)
            {
                // losing
            }
            else if (scoreBoard.My == scoreBoard.Rival)
            {
                // drawing
            }
            else
            {
                // winning
            }
        }



        public override FieldPosition GetInitialPosition() => FieldPosition.A2;


        //Patear penal
        public TargetPreference PenaltyKickPreference { get; } = new TargetPreference(2, 2, 10);
        //Atajar penal
        public TargetPreference PenaltyDivePreference { get; } = new TargetPreference(2, 2, 10);




        public override string GetPlayerDisplayName() => "Muñeco Gallardo";
    }
}
