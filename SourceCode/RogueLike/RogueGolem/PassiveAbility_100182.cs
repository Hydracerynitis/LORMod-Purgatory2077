// Decompiled with JetBrains decompiler
// Type: Ark.PassiveAbility_100100
// Assembly: Purgatory, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 5C0C2E20-DF17-4E33-88D7-BA075DE8EB20
// Assembly location: D:\SteamLibrary\steamapps\common\Library Of Ruina\LibraryOfRuina_Data\Mods\Purgatory2077\Assemblies\Purgatory.dll

namespace Ark
{
    //速度骰子锁定为1颗 每隔两幕在战斗开始时使自身[陷入晕眩]
    public class PassiveAbility_100182 : PassiveAbilityBase
    {
        public int GetSpeedDiceNumLast() => 1;
        public override void OnRoundEnd()
        {
            if (StageController.Instance.RoundTurn % 3 == 2)
                owner.bufListDetail.AddKeywordBufByEtc(KeywordBuf.Stun, 1);
        }
    }
}
