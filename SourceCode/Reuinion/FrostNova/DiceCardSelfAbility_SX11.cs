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
    //当有友方单位死亡时才能使用     使本书页所有骰子威力增加全体友方单位的[束缚]层数总和
    public class DiceCardSelfAbility_SX11 : DiceCardSelfAbilityBase
    {
        public static string Desc = "当有友方单位死亡时才能使用\n使本书页所有骰子威力增加全体友方单位的[束缚]层数总和";
        public override bool OnChooseCard(BattleUnitModel owner) => BattleObjectManager.instance.GetList(owner.faction).Exists(x => x.IsDead());
        public override void OnUseCard()
        {
            int bindingStack = 0;
            BattleObjectManager.instance.GetAliveList(owner.faction).ForEach(x => bindingStack += x.bufListDetail.GetKewordBufStack(KeywordBuf.Binding));
            card.ApplyDiceStatBonus(DiceMatch.AllDice, new DiceStatBonus() { power = bindingStack });
        }
    }
}
