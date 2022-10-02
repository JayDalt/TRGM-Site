using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TRGM_Site.Models;

namespace TRGM_Site.Pages
{
public class CustomLoadOutPageModel : PageModel
{

[BindProperty]
public string UnitType { get; set; }

[BindProperty]
public string TextInput { get; set; }

[BindProperty]
public string ResultText { get; set; }
       
public void OnPost()
{
    var loadoutRequest = new LoadoutRequest();

    loadoutRequest.TextInput = TextInput;
    loadoutRequest.UnitType = UnitType;

    ResultText = CustomLoadOutGenerator(loadoutRequest);
}

    public string CustomLoadOutGenerator(LoadoutRequest something)
    {
        return null;

        //add API code locally (temp)
    }

    public string LoadoutRequest()
    {
        return null;
    }

}


}


