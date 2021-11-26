// Decompiled with JetBrains decompiler
// Type: Ark.PassiveAbility_100016
// Assembly: Purgatory, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 5C0C2E20-DF17-4E33-88D7-BA075DE8EB20
// Assembly location: D:\SteamLibrary\steamapps\common\Library Of Ruina\LibraryOfRuina_Data\Mods\Purgatory2077\Assemblies\Purgatory.dll

using System.Collections.Generic;

namespace Ark
{
    //疾速追杀  自身每使用两张不同的书页，则使第三张书页的进攻型骰子下限+3
    public class PassiveAbility_100016 : PassiveAbilityBase
    {
        private List<LorId> _cardIdList = new List<LorId>();
        public override void OnUseCard(BattlePlayingCardDataInUnitModel curCard)
        {
            LorId id = curCard.card.GetID();
            if (_cardIdList.Count < 2)
            {
                if (!_cardIdList.Contains(id))
                    _cardIdList.Add(id);
                return;
            }
            _cardIdList.Clear();
            curCard.ApplyDiceStatBonus(DiceMatch.AllAttackDice, new DiceStatBonus(){ min = 3 });
        }
    }
}
