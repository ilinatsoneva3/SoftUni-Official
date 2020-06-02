namespace PlayersAndMonsters.Models.BattleFields
{
    using PlayersAndMonsters.Models.BattleFields.Contracts;
    using PlayersAndMonsters.Models.Players;
    using PlayersAndMonsters.Models.Players.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class BattleField : IBattleField
    {
        public void Fight(IPlayer attackPlayer, IPlayer enemyPlayer)
        {
            if (attackPlayer.IsDead || enemyPlayer.IsDead)
            {
                throw new ArgumentException("Player is dead!");
            }

            if (attackPlayer is Beginner)
            {
                this.ModifyBeginnerHealthAndDamagePoints(attackPlayer);
            }

            if (enemyPlayer is Beginner)
            {
                this.ModifyBeginnerHealthAndDamagePoints(enemyPlayer);
            }

            attackPlayer = this.AddPlayerHealthPoints(attackPlayer);
            enemyPlayer = this.AddPlayerHealthPoints(enemyPlayer);

            while (!attackPlayer.IsDead && !enemyPlayer.IsDead)
            {
                var attackPlayerDamagePoints = this.CalculateDamagePoints(attackPlayer);

                enemyPlayer.TakeDamage(attackPlayerDamagePoints);

                if (enemyPlayer.IsDead)
                {
                    break;
                }

                var enemyPlayerDamagePoints = this.CalculateDamagePoints(enemyPlayer);

                attackPlayer.TakeDamage(enemyPlayerDamagePoints);
            }
        }

        private void ModifyBeginnerHealthAndDamagePoints(IPlayer player)
        {
            player.Health += 40;

            foreach (var card in player.CardRepository.Cards)
            {
                card.DamagePoints += 30;
            }
        }

        private IPlayer AddPlayerHealthPoints (IPlayer player)
        {
            player.Health += player
                .CardRepository
                .Cards
                .Select(c => c.HealthPoints)
                .Sum();

            return player;
        }

        private int CalculateDamagePoints(IPlayer player)
        {
            return player
                .CardRepository
                .Cards
                .Select(c => c.DamagePoints)
                .Sum();
        }
    }
}
