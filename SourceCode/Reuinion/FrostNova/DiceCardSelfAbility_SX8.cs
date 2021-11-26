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
    //[使用时] 使本书页所有骰子威力增加全体友方单位的[束缚]层数总和     若已转移核心书页[寒灾]则使本书页骰子最大值增加自身[束缚]的层数
    public class DiceCardSelfAbility_SX8 : DiceCardSelfAbilityBase
    {
        private const int FrozenMonstrosityEquipPageId = 1;
        public static string Desc = "[使用时] 使本书页所有骰子威力增加全体友方单位的[束缚]层数总和\n若已转移核心书页[寒灾]则使本书页骰子最大值增加自身[束缚]的层数";
        public override void OnUseCard()
        {
            int bindingStack = 0;
            BattleObjectManager.instance.GetAliveList(owner.faction).ForEach(x => bindingStack += x.bufListDetail.GetKewordBufStack(KeywordBuf.Binding));
            int selfStack = 0;
            List<BookModel> EquipedBook = owner.equipment.book.GetEquipedBookList(true);
            foreach (BookModel model in EquipedBook)
            {
                if (model.BookId == new LorId("Purgatory2077", FrozenMonstrosityEquipPageId))
                    selfStack = owner.bufListDetail.GetKewordBufStack(KeywordBuf.Binding);
            }
            card.ApplyDiceStatBonus(DiceMatch.AllDice, new DiceStatBonus() { power = bindingStack, max = selfStack });
        }
    }
}
