using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using testing_picking.AppService;
using Microsoft.Extensions.DependencyInjection;
using testing_picking.Models.TransferInbound;
using testing_picking.Models.BorderPicking;
using testing_picking.Models.Divert;
using testing_picking.Models.Confirm;

public class Program
{
    private readonly IApisAppService _api;

    public Program(IApisAppService api)
    {
        _api = api;
    }

    static async Task Main()
    {
        var apiService = new Apis();

        string username = "joseangel@gmail.com";
        string password = "26091999aA*";

        string bearerToken = await apiService.GetBearerTokenAsync(username, password);


    }
}


