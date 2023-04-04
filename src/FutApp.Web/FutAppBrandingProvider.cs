using Volo.Abp.Ui.Branding;
using Volo.Abp.DependencyInjection;

namespace FutApp.Web;

[Dependency(ReplaceServices = true)]
public class FutAppBrandingProvider : DefaultBrandingProvider
{
    public override string AppName => "FutApp";
}
