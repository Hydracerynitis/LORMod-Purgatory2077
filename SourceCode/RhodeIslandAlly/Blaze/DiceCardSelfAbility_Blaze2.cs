// Decompiled with JetBrains decompiler
// Type: Ark.DiceCardSelfAbility_42ts
// Assembly: Purgatory, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 5C0C2E20-DF17-4E33-88D7-BA075DE8EB20
// Assembly location: D:\SteamLibrary\steamapps\common\Library Of Ruina\LibraryOfRuina_Data\Mods\Purgatory2077\Assemblies\Purgatory.dll

using LOR_DiceSystem;
using System.Collections.Generic;
using HarmonyLib;

namespace Ark
{
    //[使用时]使本书页所有骰子基础值+2且书页费用+1(不包含同名书页)
    public class DiceCardSelfAbility_Blaze2 : DiceCardSelfAbilityBase
    {
        public static string Desc = "[使用时]使本书页所有骰子基础值+2且书页费用+1(不包含同名书页)";
        public override void OnUseCard()
        {
            card.card.AddBuf(new CostIncrease());
            DiceCardXmlInfo xmlData = card.card.XmlData;
            List<DiceBehaviour> diceBehaviourList = new List<DiceBehaviour>();
            foreach (DiceBehaviour diceBehaviour1 in xmlData.DiceBehaviourList)
            {
                DiceBehaviour diceBehaviour2 = diceBehaviour1.Copy();
                diceBehaviour2.Dice += 2;
                diceBehaviour2.Min += 2;
                diceBehaviourList.Add(diceBehaviour2);
            }
            xmlData.DiceBehaviourList = diceBehaviourList;
        }
    }
}
