﻿namespace BethanysPieShop.Client.Models;

public class UserShoppingCartItem
{
    public string UserId { get; set; }
    public ShoppingCartItem ShoppingCartItem { get; set; }
}
