using FFXIVClientStructs.FFXIV.Client.Game.Character;
using EventHandler = FFXIVClientStructs.FFXIV.Client.Game.Event.EventHandler;

namespace HaselTweaks.Structs;

public unsafe partial struct Statics
{
    [MemberFunction("E8 ?? ?? ?? ?? 8B 44 24 78 89 44 24 44")]
    public static partial void GetTodoArgs(EventHandler* questEventHandler, BattleChara* localPlayer, int i, uint* numHave, uint* numNeeded, uint* itemId);
}
