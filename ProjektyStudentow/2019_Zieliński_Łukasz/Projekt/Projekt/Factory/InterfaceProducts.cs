using System;
using Projekt.Prototype;

namespace Projekt.Factory
{
    // zestaw nazwanych stałych, lista modułów wyliczających

    // sygnatury 
    public interface InterfaceProducts 
    {

        string name { get; }
        int height { get; }
        int width { get; }
        int length { get; }
        int cost { get; }

    }
}