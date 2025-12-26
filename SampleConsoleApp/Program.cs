using Microsoft.EntityFrameworkCore;
using SampleConsoleApp;
using System;


Console.WriteLine("Start the application! \n");
Authorization auth = new Authorization();
using (var context = new AppDbContext())
{
    if(auth.Token == "ABCD12345xyz")
    {
    await context.Database.EnsureCreatedAsync();
    if(auth.UserName == "AbcdUser" && auth.Password == "P@ssword1")
    {
        Console.WriteLine("Authorized User. \n");
        var empList = await context.GetAllEmployeesAsync();
    Console.WriteLine("Users from db.\n");
    foreach (var emp in empList)
    {
        Console.WriteLine($"EmpId : {emp.EmpId} Name : {emp.Name} Skill : {emp.Skill}\n");
    }
    Console.WriteLine("End\n");
    }
    else
    {
        Console.WriteLine("Invalid Credentials. \n");
        return;
    }
    }
    else
    {
        Console.WriteLine("Unauthorized User. \n");
    }
}
