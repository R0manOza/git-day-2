using MidtermExam5;
using System;
MidetermExamContext db = new MidetermExamContext();

var q = db.Vendors.Where (v => !db.Products.Select(p => p.VendorId).Contains(v.Id)); 
foreach (var item  in q)
    Console.WriteLine(item.VendorName);
