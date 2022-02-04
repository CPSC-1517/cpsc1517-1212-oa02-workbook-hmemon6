// See https://aka.ms/new-console-template for more information

using Struct_Demo;

Resolution hdResolution = new(1920, 1080);
var cinemaResolution = hdResolution;
cinemaResolution.Width = 2048; 
Console.WriteLine($"HD resolution is {hdResolution.Width} pixels wide and {hdResolution.Height} pixels height");
Console.WriteLine($"HD resolution is {cinemaResolution.Width} pixels wide and {cinemaResolution.Height} pixels height");

/*
 *  Struct is a value type meaning it will make the copy of origianl value and change it while retaining th eoriginal valuess
 *  
 *  
 *  class is a reference type meaningn it will reference teh newly create object with the original values, will change the values
 *  once itf references.
 * 
 * 
 * 
 * 
 */



//VideoMode someVideoMode = new();

