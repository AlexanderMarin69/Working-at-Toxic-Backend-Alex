﻿using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using RestaurantDecider.Interfaces;
using RestaurantDecider.Models;
using RestaurantDecider.Services;

namespace RestaurantDecider.Controllers;

public class HomeController : Controller
{

    IRestaurantService _restaurantService;

    public HomeController(IRestaurantService restaurantService)
    {
        _restaurantService = restaurantService;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Restaurant()
    {
        return View(_restaurantService.PickRandom());
    }

    public IActionResult Add([FromForm] Restaurant restaurant)
    {
        _restaurantService.Add(restaurant);
        return View("Index");
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}

