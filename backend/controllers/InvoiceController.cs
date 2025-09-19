
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace BuggyApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class InvoiceController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetInvoice()
        {
            List<Invoice> invoices = new ArrayList<Invoice>();

            Item itemLocal1 = new Item("Chips", 10);
            Item itemLocal2 = new Item("Juice", 25);
            List<Item> listAllItems1 = new ArrayList<Item>();
            listAllItems1.add(itemLocal1);
            listAllItems1.add(itemLocal2);
            Invoice invoice1 = new Invoice("John Doe", listAllItems1);
            invoices.add(invoice1);

            Item itemLocal3 = new Item("Pizza", 100.5);
            Item itemLocal4 = new Item("Burger", 95.7);
            List<Item> listAllItems2 = new ArrayList<Item>();
            listAllItems2.add(itemLocal3);
            listAllItems2.add(itemLocal4);
            Invoice invoice2 = new Invoice("Max Alice", listAllItems2);
            invoices.add(invoice2);

            if (invoices.Count != 0) // NullReferenceException
            {
                return Ok(new { invoices });
            }
            return NotFound("No invoice found");
        }

        public class Item
        {
            Item(string Name, double Price)
            {
                this.Name = Name;
                this.Price = Price;
            }
            public string Name { get; set; }
            public double Price { get; set; }
        }

        public class Invoice
        {
            Invoice(string CustomerName, Item[] Items)
            {
                this.CustomerName = CustomerName;
                this.Items = Items;    
            }

            public string CustomerName { get; set; }
            public Item[] Items { get; set; }
        }
    }
}
