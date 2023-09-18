using Volo.Abp.Settings;

namespace Baharan.Settings;

public class BaharanSettingDefinitionProvider : SettingDefinitionProvider
{
    public override void Define(ISettingDefinitionContext context)
    {
        //Define your own settings here. Example:
        //context.Add(new SettingDefinition(BaharanSettings.MySetting1));
    }
}
