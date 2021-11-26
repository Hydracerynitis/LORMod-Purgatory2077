// Decompiled with JetBrains decompiler
// Type: Ark.DiceCardSelfAbility_42ts
// Assembly: Purgatory, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 5C0C2E20-DF17-4E33-88D7-BA075DE8EB20
// Assembly location: D:\SteamLibrary\steamapps\common\Library Of Ruina\LibraryOfRuina_Data\Mods\Purgatory2077\Assemblies\Purgatory.dll

using System.Collections.Generic;
using HarmonyLib;

namespace Ark
{
    //[使用时] 下一幕抽取3张书页并且向手中置入随机2张[黑蛇]书页
    public class DiceCardSelfAbility_TLL9 :DiceCardSelfAbilityBase 
    {
        private static List<int> BlackSnakeCombatPageId = new List<int>() { 1, 2, 3 };
        public static string Desc = "[使用时] 下一幕抽取3张书页并且向手中置入随机2张[黑蛇]书页";
        public override void OnUseCard()
        {
            owner.bufListDetail.AddBuf(new DrawCard(3));
            owner.allyCardDetail.AddNewCard(new LorId("Purgatory2077", RandomUtil.SelectOne<int>(BlackSnakeCombatPageId)));
            owner.allyCardDetail.AddNewCard(new LorId("Purgatory2077", RandomUtil.SelectOne<int>(BlackSnakeCombatPageId)));
        }
    }
}
