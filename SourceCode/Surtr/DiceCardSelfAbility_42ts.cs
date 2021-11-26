// Decompiled with JetBrains decompiler
// Type: Ark.DiceCardSelfAbility_42ts
// Assembly: Purgatory, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 5C0C2E20-DF17-4E33-88D7-BA075DE8EB20
// Assembly location: D:\SteamLibrary\steamapps\common\Library Of Ruina\LibraryOfRuina_Data\Mods\Purgatory2077\Assemblies\Purgatory.dll

using System.Collections.Generic;

namespace Ark
{
    //这一幕结束时若本书页有骰子还未使用则在下一幕获得2层[强壮]
    public class DiceCardSelfAbility_42ts : DiceCardSelfAbilityBase
    {
        public static string Desc = "这一幕结束时若本书页有骰子还未使用则在下一幕获得2层[强壮]";
        public override void OnStartBattleAfterCreateBehaviour()
        {
            owner.bufListDetail.AddBuf(new BattleUnitBuf_SurtrDefense(){ dicebehaviours = card.GetDiceBehaviorList() });
        }

        public class BattleUnitBuf_SurtrDefense : BattleUnitBuf
        {
            public List<BattleDiceBehavior> dicebehaviours = new List<BattleDiceBehavior>();

            public override void OnRoundEnd()
            {
                foreach(BattleDiceBehavior dice in _owner.cardSlotDetail.keepCard.GetDiceBehaviorList())
                {
                    if(dicebehaviours.Contains(dice))
                    {
                        _owner.bufListDetail.AddKeywordBufByCard(KeywordBuf.Strength, 2, _owner);
                        break;
                    }
                }
                this.Destroy();
            }
        }
    }
}
