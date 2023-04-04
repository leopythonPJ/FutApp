using System;
using System.Collections.Generic;
using System.Text;
using FutApp.Localization;
using Volo.Abp.Application.Services;

namespace FutApp;

/* Inherit your application services from this class.
 */
public abstract class FutAppAppService : ApplicationService
{
    protected FutAppAppService()
    {
        LocalizationResource = typeof(FutAppResource);
    }
}
