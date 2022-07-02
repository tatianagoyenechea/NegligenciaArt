using Core.Games;
using Core.Player;
using JetBrains.Annotations;
using UnityEngine;

namespace Teams.Negligencia_Artificial
{
    [UsedImplicitly]
    public class ExampleTeam : Team
    {
        public TargetPreference PenaltyDivePreference { get; } = new TargetPreference(3,1,4);

        public TargetPreference PenaltyKickPreference { get; } = new TargetPreference(2,1,2);
        
        public TeamPlayer GetPlayerOne() => new Goalkeeper();

        public TeamPlayer GetPlayerTwo() => new PlayerTwo();

        public TeamPlayer GetPlayerThree() => new PlayerThree();
        
        public Color PrimaryColor => new Color(0.9f, 0.0f, 0.0f);

        public string GetName() => "Negligencia Artificial";

        public string TeamShield => "Negligencia";

    }
} 