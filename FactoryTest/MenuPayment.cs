using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryTest
{
    public class PaymentApp
    {
        private ConsoleMenu menu = new ConsoleMenu();        
        private Product product;

        public PaymentApp(Product product)
        {
            this.product = product;

            menu.AddItem(new MenuItem { ShortcutChar = '1', Text = "Transilvania Bank", ActionToExecute = new MenuItemAction(ProcessPayment), ContextObject = new TransilvaniaProcesor() });
            menu.AddItem(new MenuItem { ShortcutChar = '2', Text = "Unicredit Bank", ActionToExecute = new MenuItemAction(ProcessPayment), ContextObject = new UnicreditProcesor() });
            menu.AddItem(new MenuItem { ShortcutChar = '3', Text = "Paypal Bank", ActionToExecute = new MenuItemAction(ProcessPayment), ContextObject = new PayPalProcesor() });
            menu.AddItem(new MenuItem { ShortcutChar = '4', Text = "BRD Bank", ActionToExecute = new MenuItemAction(ProcessPayment), ContextObject = new BRDProcesor() });
            //menu.AddItem(new MenuItem { ShortcutChar = '5', Text = "Best Bank", ActionToExecute = new MenuItemAction(UseBestPayment), ContextObject = product });
        }

        public void Run()
        {
            menu.Run();
        }

        private void ProcessPayment(object sender, object contextObject)
        {
           PaymentProcessor paymentProcessor = (PaymentProcessor)contextObject;
            paymentProcessor.MakePayment(product);
        }        
    }
}
