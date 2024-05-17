using Dalamud.Game.ClientState.Keys;
using FFXIVClientStructs.FFXIV.Client.UI.Agent;
using FFXIVClientStructs.FFXIV.Component.GUI;
using HaselCommon.Enums;
using HaselCommon.Services;
using HaselTweaks.Windows;
using Lumina.Excel.GeneratedSheets;
using ValueType = FFXIVClientStructs.FFXIV.Component.GUI.ValueType;

namespace HaselTweaks.Tweaks;

public class AetherCurrentHelperConfiguration
{
    [BoolConfig]
    public bool AlwaysShowDistance = false;

    [BoolConfig]
    public bool CenterDistance = true;
}

[Tweak]
public unsafe partial class AetherCurrentHelper : Tweak<AetherCurrentHelperConfiguration>
{
    public override void Disable()
    {
        if (Service.HasService<WindowManager>())
            Service.WindowManager.CloseWindow<AetherCurrentHelperWindow>();
    }

    [VTableHook<AgentAetherCurrent>((int)AgentInterfaceVfs.ReceiveEvent)]
    private AtkValue* AgentAetherCurrent_ReceiveEvent(AgentAetherCurrent* agent, AtkValue* eventData, AtkValue* atkValue, uint valueCount, nint eventKind)
    {
        if (OpenWindow(agent, atkValue))
        {
            // handled, just like in the original code
            eventData->Type = ValueType.Bool;
            eventData->Byte = 0;
            return eventData;
        }

        return AgentAetherCurrent_ReceiveEventHook.OriginalDisposeSafe(agent, eventData, atkValue, valueCount, eventKind);
    }

    public static bool OpenWindow(AgentAetherCurrent* agent, AtkValue* atkValue)
    {
        if (Service.KeyState[VirtualKey.SHIFT])
            return false;

        if (atkValue == null)
            return false;

        ref var firstAtkValue = ref atkValue[0];
        if (firstAtkValue.Type != ValueType.Int || firstAtkValue.Int != 0)
            return false;

        ref var secondAtkValue = ref atkValue[1];
        if (secondAtkValue.Type != ValueType.Int)
            return false;

        var rawIndex = (uint)(secondAtkValue.Int + 6 * agent->TabIndex);
        var index = rawIndex + 1;
        if (index < 19)
            index = rawIndex;

        var compFlgSet = GetRow<AetherCurrentCompFlgSet>(index + 1);
        if (compFlgSet == null)
            return false;

        var window = Service.WindowManager.OpenWindow<AetherCurrentHelperWindow>();
        window.CompFlgSet = compFlgSet;

        return true;
    }
}
