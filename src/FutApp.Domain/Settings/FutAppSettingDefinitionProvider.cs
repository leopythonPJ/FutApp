using Volo.Abp.Settings;

namespace FutApp.Settings;

public class FutAppSettingDefinitionProvider : SettingDefinitionProvider
{
    public override void Define(ISettingDefinitionContext context)
    {
        //Define your own settings here. Example:
        //context.Add(new SettingDefinition(FutAppSettings.MySetting1));
    }
}
