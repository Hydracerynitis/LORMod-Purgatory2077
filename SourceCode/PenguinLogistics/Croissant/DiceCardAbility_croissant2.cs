// Decompiled with JetBrains decompiler
// Type: Ark.DiceCardAbility_croissant2
// Assembly: Purgatory, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 5C0C2E20-DF17-4E33-88D7-BA075DE8EB20
// Assembly location: D:\SteamLibrary\steamapps\common\Library Of Ruina\LibraryOfRuina_Data\Mods\Purgatory2077\Assemblies\Purgatory.dll

namespace Ark
{
    //"本骰子造成混乱伤害x2"
    public class DiceCardAbility_croissant2 : DiceCardAbilityBase
    {
        public static string Desc = "本骰子造成混乱伤害x2";
        public override void BeforeRollDice()
        {
            behavior.ApplyDiceStatBonus(new DiceStatBonus(){ breakRate = 100 });
        }
    }
}
