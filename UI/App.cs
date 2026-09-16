using Stockastic.Data;
using System;
using System.Collections.Generic;
using System.Text;
namespace Stockastic.UI;
public class App(MainMenu mainMenu)
{
    public async Task Show()=>
        await mainMenu.Show();
}
