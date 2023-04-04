using FutApp.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace FutApp.Controllers;

/* Inherit your controllers from this class.
 */
public abstract class FutAppController : AbpControllerBase
{
    protected FutAppController()
    {
        LocalizationResource = typeof(FutAppResource);
    }
}
