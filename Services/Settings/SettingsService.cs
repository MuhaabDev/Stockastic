using Microsoft.EntityFrameworkCore;
using Stockastic.Data;
using Stockastic.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
namespace Stockastic.Services.Settings;
public class SettingsService(ApplicationDbContext context)
{
    public async Task ChangeColor(User user, string colorName)
    {
        if (!Enum.TryParse<ConsoleColor>(colorName,true, out ConsoleColor selectedColor))
            throw new ArgumentException("Invalid color.");
        
        if (selectedColor == ConsoleColor.Black)
            throw new ArgumentException("Black color is not allowed.");
       
        user.SelectedColor = selectedColor;
        Console.ForegroundColor = selectedColor;
        await context.SaveChangesAsync();
    }
}