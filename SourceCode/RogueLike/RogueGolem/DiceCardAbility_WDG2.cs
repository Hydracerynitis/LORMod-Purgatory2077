// Decompiled with JetBrains decompiler
// Type: Ark.DiceCardSelfAbility_42ts
// Assembly: Purgatory, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 5C0C2E20-DF17-4E33-88D7-BA075DE8EB20
// Assembly location: D:\SteamLibrary\steamapps\common\Library Of Ruina\LibraryOfRuina_Data\Mods\Purgatory2077\Assemblies\Purgatory.dll

using System.Collections.Generic;
using HarmonyLib;
using LOR_DiceSystem;

namespace Ark
{
    //[命中时]使目标下一幕中[手牌上限]-8
    public class DiceCardAbility_WDG2 : DiceCardAbilityBase 
    {
        public static string Desc = "[命中时]使目标下一幕中[手牌上限]-8";
        public override void OnSucceedAttack()
        {
            card.target.bufListDetail.AddReadyBuf(new LowHand());
        }
        public class LowHand : BattleUnitBuf
        {
            private int originalHand = -1;
            public override void Init(BattleUnitModel owner)
            {
                base.Init(owner);
                if(originalHand<0)  
                    originalHand = (int)typeof(BattleAllyCardDetail).GetField("_maxDrawHand", AccessTools.all).GetValue(owner.allyCardDetail);
                owner.allyCardDetail.SetMaxDrawHand(originalHand - 8);
            }
            public override void OnRoundEnd()
            {
                base.OnRoundEnd();
                Destroy();
            }
            public override void Destroy()
            {
                base.Destroy();
                _owner.allyCardDetail.SetMaxDrawHand(originalHand);
            }
        }
    }
}
