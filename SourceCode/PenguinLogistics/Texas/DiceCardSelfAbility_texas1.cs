// Decompiled with JetBrains decompiler
// Type: Ark.DiceCardSelfAbility_texas1
// Assembly: Purgatory, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 5C0C2E20-DF17-4E33-88D7-BA075DE8EB20
// Assembly location: D:\SteamLibrary\steamapps\common\Library Of Ruina\LibraryOfRuina_Data\Mods\Purgatory2077\Assemblies\Purgatory.dll

namespace Ark
{
    //[使用时]抽取1张书页并摧毁本书页所有骰子 下一幕将获得一张特殊战斗书页
    public class DiceCardSelfAbility_texas1 : DiceCardSelfAbilityBase
    {
        public static string Desc = "[使用时]抽取1张书页并摧毁本书页所有骰子 下一幕将获得一张特殊战斗书页";
        public override string[] Keywords => new string[1]{ "AreaCard_Keyword" };
        public override void OnUseCard()
        {
            owner.allyCardDetail.DrawCards(1);
            owner.allyCardDetail.AddNewCard(new LorId("Purgatory2077", 100));
            card.RemoveAllDice();
        }
    }
}
