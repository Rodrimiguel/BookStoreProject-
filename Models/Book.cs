using BOOKSTORE00.Utils;

namespace BOOKSTORE00.Models;

public class Book

{
    public int Id {get;set;}

    public string Name {get;set;}

    public string Editorial {get;set;}
    
    public decimal Price {get;set;}

    public BookCondition Condition {get;set;}

    public bool withcdordvd {get;set;} = false;  

}