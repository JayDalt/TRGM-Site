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

    ResultText = CustomLoadoutGenerator(loadoutRequest);
}
        private string CustomLoadoutGenerator(LoadoutRequest request)
        {
            //add API code locally (temp)

            string sResult = "";
            string ResultText = "";
            foreach (string strLine in request.TextInput.Split(Environment.NewLine))
            {
                int iInnerLoopCount = 0;
                string adjustedString = strLine.Replace(Environment.NewLine, "").Replace("\n", "");

                if (adjustedString.Substring(0, 7) != "comment" && adjustedString != "" && adjustedString.Substring(0, 6) != "remove")
                {
                    string sTempResult = adjustedString;
                    if (adjustedString.Substring(0, 3) == "for")
                    {
                        string sLoopCount = adjustedString.Substring(adjustedString.IndexOf("from 1 to ") + 10);
                        sLoopCount = sLoopCount.Substring(sLoopCount.IndexOf(" do")).Trim();
                        if (sLoopCount.All(char.IsNumber))
                            iInnerLoopCount = Convert.ToInt32(sLoopCount) - 1;
                        sTempResult = adjustedString.Substring(adjustedString.IndexOf("{") + 1, adjustedString.Length);
                        sTempResult = sTempResult.Substring(0, sTempResult.IndexOf("}") - 1);
                    }
                    sTempResult = sTempResult.Replace("this ", "");
                    sTempResult = sTempResult.Replace(" \"", "=");
                    sTempResult = sTempResult.Replace("\";", ";");

                    for (int i = 0; i <= iInnerLoopCount; i++)
                        sResult += sTempResult + Environment.NewLine;
                }
            }
            request.TextInput = "";
            return ResultText = "#" + Environment.NewLine + request.UnitType + ":" + Environment.NewLine + sResult;

        }


        /* public string CustomLoadOutGenerator(LoadoutRequest something)
         {
             return null;

         }*/

        public string LoadoutRequest()
    {
        return null;
    }

}


}


