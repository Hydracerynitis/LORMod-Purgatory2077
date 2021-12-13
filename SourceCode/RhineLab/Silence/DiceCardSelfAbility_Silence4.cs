// Decompiled with JetBrains decompiler
// Type: Ark.DiceCardSelfAbility_Silence1
// Assembly: Purgatory, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 5C0C2E20-DF17-4E33-88D7-BA075DE8EB20
// Assembly location: D:\SteamLibrary\steamapps\common\Library Of Ruina\LibraryOfRuina_Data\Mods\Purgatory2077\Assemblies\Purgatory.dll

namespace Ark
{
    //[使用时]下一幕中使手中所有书页获得[莱茵镀层]
    public class DiceCardSelfAbility_Silence4 : DiceCardSelfAbilityBase
    {
        public static string Desc = "[使用时]下一幕中使手中所有书页获得[莱茵镀层]";
        public override void OnUseCard()
        {
            owner.bufListDetail.AddBuf(new Shading());
        }
        public class Shading: BattleUnitBuf
        {
            public override void OnRoundStart()
            {
                _owner.allyCardDetail.GetAllDeck().ForEach(x => x.AddBuf(new RhineShade()));
                Destroy();
            }
        }
        public override string[] Keywords => new string[1]{ "RhineShade" };
    }
}
