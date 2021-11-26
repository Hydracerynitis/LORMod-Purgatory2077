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
    //[战斗开始] 这一幕受到的混乱伤害-2并在下一幕抽取一张书页
    public class DiceCardSelfAbility_W0 :DiceCardSelfAbilityBase 
    {
        public static string Desc = "[战斗开始] 这一幕受到的混乱伤害-2并在下一幕抽取一张书页";
        public override void OnStartBattle() => owner.bufListDetail.AddBuf(new DrawCard());
        public class DrawCard: BattleUnitBuf
        {
            public override int GetBreakDamageReduction(BehaviourDetail behaviourDetail) => 2;
            public override void OnRoundEnd()
            {
                base.OnRoundEnd();
                _owner.allyCardDetail.DrawCards(1);
                Destroy();
            }
        }
    }
}
