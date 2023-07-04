using BOOKSTORE00.Models;
using BOOKSTORE00.Utils;

namespace BOOKSTORE00.ViewModels;

public class BookDetailViewModel
{ // CREACION DE VIEWMODEL

    public int Id { get; set; } // ID PARA BASE DE DATOS.


    public string Name { get; set; }


    public string Autor { get; set; }


    public string Editorial { get; set; }


    public decimal Price { get; set; }


    public BookCondition Condition { get; set; }


    public bool withcdordvd { get; set; } = false;

}