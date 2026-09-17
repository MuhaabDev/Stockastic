using Stockastic.Domain.Entities;
using Stockastic.Services.Trading_Service;
using System;
using System.Collections.Generic;
using System.Text;
namespace Stockastic.UI.Trading_Page;
public class HoldingsMenu(HoldingServices holdingServices)
{
    public async Task Show(User currentUser)
    {
        bool inHoldingMenu = true;
        while (inHoldingMenu)
        {
            DisplayMenu();

        }
    }

    private void DisplayMenu()
    {
        throw new NotImplementedException();
    }
}