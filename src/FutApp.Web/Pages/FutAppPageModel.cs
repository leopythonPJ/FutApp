using FutApp.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace FutApp.Web.Pages;

/* Inherit your PageModel classes from this class.
 */
public abstract class FutAppPageModel : AbpPageModel
{
    protected FutAppPageModel()
    {
        LocalizationResourceType = typeof(FutAppResource);
    }
}
