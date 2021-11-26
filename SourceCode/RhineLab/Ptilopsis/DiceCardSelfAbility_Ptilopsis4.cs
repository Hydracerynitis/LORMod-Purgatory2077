// Decompiled with JetBrains decompiler
// Type: Ark.DiceCardSelfAbility_Ptilopsis4
// Assembly: Purgatory, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 5C0C2E20-DF17-4E33-88D7-BA075DE8EB20
// Assembly location: D:\SteamLibrary\steamapps\common\Library Of Ruina\LibraryOfRuina_Data\Mods\Purgatory2077\Assemblies\Purgatory.dll

namespace Ark
{
    //[使用时]所有友方消耗1层[充能]并恢复5点混乱抗性
    public class DiceCardSelfAbility_Ptilopsis4 : DiceCardSelfAbilityBase
    {
        public static string Desc = "[使用时]所有友方消耗1层[充能]并恢复5点混乱抗性";
        public override void OnUseCard()
        {
            foreach (BattleUnitModel alive in BattleObjectManager.instance.GetAliveList(owner.faction))
            {
                if(alive.bufListDetail.GetActivatedBuf(KeywordBuf.WarpCharge) is BattleUnitBuf_warpCharge activatedBuf && activatedBuf.stack >= 1)
                {
                    activatedBuf.UseStack(1, true);
                    alive.breakDetail.RecoverBreak(5);
                }
            }
        }
        public override string[] Keywords => new string[1]{ "WarpCharge" };
    }
}
