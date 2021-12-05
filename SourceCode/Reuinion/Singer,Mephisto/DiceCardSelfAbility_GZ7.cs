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
    //自身[束缚]层数不低于10时可用
    public class DiceCardSelfAbility_GZ7 : DiceCardSelfAbilityBase
    {
        public static string Desc = "这一幕中拼点胜利时对所有敌方单位施加1层[束缚]";
        public override void OnUseCard()
        {
            owner.bufListDetail.AddBuf(new Singer());
        }
        public class Singer: BattleUnitBuf
        {
            public override void OnWinParrying(BattleDiceBehavior behavior)
            {
                foreach (BattleUnitModel unit in BattleObjectManager.instance.GetAliveList_opponent(_owner.faction))
                    unit.bufListDetail.AddKeywordBufThisRoundByCard(KeywordBuf.Binding, 1);
            }
            public override void OnRoundEnd()
            {
                this.Destroy();
            }
        }
    }
}
