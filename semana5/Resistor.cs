﻿using System;

class Resistor
{
    private string[] bandas;

    public Resistor(string[] bandas)
    {
        this.bandas = bandas;
    }

    private int? ObtenerValor(string color)
    {
        switch (color)
        {
            case "negro":
                return 0;
            case "café":
                return 1;
            case "rojo":
                return 2;
            case "naranja":
                return 3;
            case "amarillo":
                return 4;
            case "verde":
                return 5;
            case "azul":
                return 6;
            case "violeta":
                return 7;
            case "gris":
                return 8;
            case "blanco":
                return 9;
            case "oro":
                return null;
            case "plata":
                return null;
            case "sin color":
                return null;
            default:
                return null;
        }
    }

    private double? ObtenerMultiplicador(string color)
    {
        switch (color)
        {
            case "negro":
                return 1;
            case "café":
                return 10;
            case "rojo":
                return 100;
            case "naranja":
                return 1000;
            case "amarillo":
                return 10000;
            case "verde":
                return 100000;
            case "azul":
                return 1000000;
            case "violeta":
                return 10000000;
            case "gris":
                return 100000000;
            case "blanco":
                return 1000000000;
            case "oro":
                return 0.1;
            case "plata":
                return 0.01;
            case "sin color":
                return 0;
            default:
                return null;
        }
    }

    private double? ObtenerTolerancia(string color)
    {
        switch (color)
        {
            case "café":
                return 1;
            case "rojo":
                return 2;
            case "verde":
                return 0.5;
            case "azul":
                return 0.25;
            case "violeta":
                return 0.1;
            case "gris":
                return 0.05;
            case "oro":
                return 5;
            case "plata":
                return 10;
            case "sin color":
                return 20;
            default:
                return null;
        }
    }

    public double? CalcularResistencia()
    {
            int? valor1 = ObtenerValor(bandas[0]);
            int? valor2 = ObtenerValor(bandas[1]);

            if (valor1 == null || valor2 == null)
                throw new ArgumentException("Las primeras dos bandas deben ser colores válidos.");

            int? valor3 = 0;
            double? multiplicador = null;
            double? tolerancia = null;

            switch (bandas.Length)
            {
                case 3:
                    multiplicador = ObtenerMultiplicador(bandas[2]);
                    return (valor1 * 10 + valor2) * multiplicador;

                case 4:
                    multiplicador = ObtenerMultiplicador(bandas[2]);
                    tolerancia = ObtenerTolerancia(bandas[3]);
                    return (valor1 * 10 + valor2) * multiplicador;

                case 5:
                case 6:
                    valor3 = ObtenerValor(bandas[2]);
                    if (valor3 == null)
                        throw new ArgumentException("La tercera banda debe ser un color válido para resistencias de 5 o 6 bandas.");
                    multiplicador = ObtenerMultiplicador(bandas[3]);
                    tolerancia = ObtenerTolerancia(bandas[4]);
                    return (valor1 * 100 + valor2 * 10 + valor3) * multiplicador;

                default:
                    throw new ArgumentException("Cantidad de bandas no soportada.");
            }
        

    }

    public double? ObtenerTolerancia()
    {
        if (bandas.Length >= 4)
        {
            return ObtenerTolerancia(bandas[bandas.Length - 1]);
        }
        return null;
    }

}
