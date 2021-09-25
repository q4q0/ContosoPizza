﻿using System.Collections.Generic;
using System.Linq;
using ContosoPizza.Models;

namespace ContosoPizza.Services
{
    public static class PizzaService
    {
        private static int nextId = 3;

        static PizzaService()
        {
            Pizzas = new List<Pizza>
            {
                new() {Id = 1, Name = "Classic Italian", IsGlutenFree = false},
                new() {Id = 2, Name = "Veggie", IsGlutenFree = true}
            };
        }

        private static List<Pizza> Pizzas { get; }

        public static List<Pizza> GetAll()
        {
            return Pizzas;
        }

        public static Pizza Get(int id)
        {
            return Pizzas.FirstOrDefault(p => p.Id == id);
        }

        public static void Add(Pizza pizza)
        {
            pizza.Id = nextId++;
            Pizzas.Add(pizza);
        }

        public static void Delete(int id)
        {
            var pizza = Get(id);
            if (pizza is null)
                return;

            Pizzas.Remove(pizza);
        }

        public static void Update(Pizza pizza)
        {
            var index = Pizzas.FindIndex(p => p.Id == pizza.Id);
            if (index == -1)
                return;

            Pizzas[index] = pizza;
        }
    }
}