using FFXIVClientStructs.FFXIV.Component.GUI;

namespace HaselTweaks.Structs.Addons;

// ctor "40 53 48 83 EC 20 48 8B D9 E8 ?? ?? ?? ?? 48 8D 05 ?? ?? ?? ?? 48 89 03 33 C0 48 89 83 ?? ?? ?? ?? 48 89 83 ?? ?? ?? ?? 48 89 83 ?? ?? ?? ?? 48 89 83 ?? ?? ?? ?? 48 89 83 ?? ?? ?? ?? 48 89 83 ?? ?? ?? ?? 48 89 83 ?? ?? ?? ?? 48 89 83 ?? ?? ?? ?? 48 89 83 ?? ?? ?? ?? 48 89 83 ?? ?? ?? ?? 80 A3"
[StructLayout(LayoutKind.Explicit, Size = 0x278)]
public unsafe struct AddonRetainerSell
{
    [FieldOffset(0)] public AtkUnitBase* AtkUnitBase;
    [FieldOffset(0x230)] public AtkComponentButton* CheckMarketPriceButton;
}