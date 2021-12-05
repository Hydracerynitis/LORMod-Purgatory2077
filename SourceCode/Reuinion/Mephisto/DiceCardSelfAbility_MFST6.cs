// Decompiled with JetBrains decompiler
// Type: Ark.DiceCardSelfAbility_42ts
// Assembly: Purgatory, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 5C0C2E20-DF17-4E33-88D7-BA075DE8EB20
// Assembly location: D:\SteamLibrary\steamapps\common\Library Of Ruina\LibraryOfRuina_Data\Mods\Purgatory2077\Assemblies\Purgatory.dll

using System.Collections.Generic;
using HarmonyLib;

namespace Ark
{
    //[使用时] 若转移了核心书页[歌者]则在下一幕开始时抽取2张书页并使本书页所有骰子威力+8
    public class DiceCardSelfAbility_MFST4 :DiceCardSelfAbilityBase 
    {
        private const int SingerEquipPageId = 10000053;
        public static string Desc = "[使用时] 若转移了核心书页[歌者]则在下一幕开始时抽取2张书页并使本书页所有骰子威力+8";
        public override void OnUseCard()
        {
            List<BookModel> EquipedBook = owner.equipment.book.GetEquipedBookList(true);
            foreach (BookModel model in EquipedBook)
            {
                if (model.BookId == new LorId("Purgatory2077", SingerEquipPageId))
                {
                    owner.bufListDetail.AddBuf(new DrawCard(2));
                    card.ApplyDiceStatBonus(DiceMatch.AllDice, new DiceStatBonus() { power = 8 });
                }
            }
        }
    }
}
