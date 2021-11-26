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
    //[使用时] 使所有敌方单位获得1层[烧伤]     若已转移[不死的黑蛇]则使所有敌方单位[烧伤]层数翻倍
    public class DiceCardSelfAbility_TLL2 : DiceCardSelfAbilityBase
    {
        private const int DeathLessBlackSnakeEquipPageId = 1;
        public static string Desc = "[使用时] 使所有敌方单位获得1层[烧伤]\n若已转移[不死的黑蛇]则使所有敌方单位[烧伤]层数翻倍";
        public override void OnUseCard()
        {
            foreach (BattleUnitModel unit in BattleObjectManager.instance.GetAliveList(owner.faction))
            {
                if (CheckEquiped())
                {
                    int burnstack = unit.bufListDetail.GetKewordBufStack(KeywordBuf.Burn);
                    unit.bufListDetail.AddKeywordBufThisRoundByEtc(KeywordBuf.Burn, burnstack);
                }
                unit.bufListDetail.AddKeywordBufThisRoundByCard(KeywordBuf.Burn, 1);
            }
        }
        private bool CheckEquiped()
        {
            List<BookModel> EquipedBook = owner.equipment.book.GetEquipedBookList(true);
            foreach (BookModel model in EquipedBook)
            {
                if (model.BookId == new LorId("Purgatory2077", DeathLessBlackSnakeEquipPageId))
                    return true;
            }
            return false;
        }
    }
}
