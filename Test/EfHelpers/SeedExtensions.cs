﻿// Copyright (c) 2019 Jon P Smith, GitHub: JonPSmith, web: http://www.thereformedprogrammer.net/
// Licensed under MIT license. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using DataLayer;
using EntityClasses;

namespace Test.EfHelpers
{
    public static class SeedExtensions
    {

        public static List<ProductStock> SeedTaxAndStock(this ExampleDbContext context)
        {
            context.SeedTwoTaxRates();
            return context.SeedExampleProductStock();
        }

        public static List<ProductStock> SeedExampleProductStock(this ExampleDbContext context)
        {
            var prodStocks = new List<ProductStock>
            {
                new ProductStock(Guid.NewGuid(), 5),
                new ProductStock(Guid.NewGuid(), 10),
                new ProductStock(Guid.NewGuid(), 20),
            };
            context.AddRange(prodStocks);
            context.SaveChanges();
            return prodStocks;
        }

        public static void SeedTwoTaxRates(this ExampleDbContext context)
        {
            var rateNow = new TaxRate(DateTime.Today, 4);
            var rate2Days = new TaxRate(DateTime.Today.AddDays(2), 9);
            context.AddRange(rateNow, rate2Days);
            context.SaveChanges();
        }
    }
}