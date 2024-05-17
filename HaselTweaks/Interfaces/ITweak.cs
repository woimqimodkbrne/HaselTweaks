namespace HaselTweaks.Interfaces;

public interface ITweak : IDisposable
{
    Type CachedType { get; }
    string InternalName { get; }
    IncompatibilityWarningAttribute[] IncompatibilityWarnings { get; }

    string Name { get; }
    string Description { get; }

    bool Outdated { get; }
    bool Ready { get; }
    bool Enabled { get; }

    void SetupGenericAddressHooks();
    void SetupAddressHooks();
    void SetupVTableHooks();

    void Enable();
    void Disable();
    void DrawConfig();
    void OnConfigChange(string fieldName);
    void OnConfigWindowClose();
    void OnLanguageChange();
    void OnInventoryUpdate();
    void OnFrameworkUpdate();
    void OnLogin();
    void OnLogout();
    void OnTerritoryChanged(ushort id);
    void OnAddonOpen(string addonName);
    void OnAddonClose(string addonName);
}
