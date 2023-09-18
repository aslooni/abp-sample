using Volo.Abp.Ui.Branding;
using Volo.Abp.DependencyInjection;

namespace Baharan.Web;

[Dependency(ReplaceServices = true)]
public class BaharanBrandingProvider : DefaultBrandingProvider
{
    public override string AppName => "Baharan";
}
