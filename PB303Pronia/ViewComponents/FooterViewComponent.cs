﻿using Microsoft.AspNetCore.Mvc;

namespace PB303Pronia.ViewComponents;

public class FooterViewComponent:ViewComponent
{
    public async Task<IViewComponentResult> InvokeAsync()
    {
        
        return View();
    }
}
