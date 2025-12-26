using Microsoft.EntityFrameworkCore;
using SampleConsoleApp;
using System;


Console.WriteLine("Start the application! \n");

using (var context = new AppDbContext())
{
    await context.Database.EnsureCreatedAsync();

    var empList = await context.GetAllEmployeesAsync();
    Console.WriteLine("Users from db.\n");
    foreach (var emp in empList)
    {
        Console.WriteLine($"EmpId : {emp.EmpId} Name : {emp.Name} Skill : {emp.Skill}\n");
    }
    Console.WriteLine("End\n");
}
