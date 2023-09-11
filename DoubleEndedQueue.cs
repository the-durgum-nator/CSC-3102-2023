using System;
using System.Security.Cryptography;

namespace DataStructures
{
    //Line Class for actually Queuing our customers.
    public class Line
    {
        private DynamicArray<Customer> darr;
        Random rand = new Random();
        public Line()
        {
            darr = new DynamicArray<Customer>();
        }

        /*    public Line(int numOfCustomers)
            {
                darr = new DynamicArray<Customer>(numOfCustomers);
                for (int i = 0; i < numOfCustomers; i++)
                {
                    darr.Set(new Customer(rand.Next(5, 26)), i);
                }
            }*/

        //Two toStringMethods; use the "printLine()" for concise viewing.
        public override string ToString()
        {
            string str = "Line: (greater position means further up the line) \n";

            if (darr != null)
            {
                for (int i = 0; i < darr.Size(); i++)
                {
                    str += "Pos: " + (i + 1) + " | " + darr.Get(i).ToString() + "\n";
                }

            }
            else
            {
                str += "Nothing. :(";
            }


            return str;
        }

        public string printLine()
        {
            String print = "";

            if (Size() > 0)
            {
                print += "C1: " + darr.Get(0).getItems();
                for (int i = 1; i < Size(); i++)
                {
                    print += ", C" + (i + 1) + ": " + darr.Get(i).getItems();
                }

            }
            return print;

        }

        //Getters/Setters for the customer's items.
        public void setCustomerVal(int position, int value)
        {
            darr.Get(position).setItems(value);
        }

        public int getCustomerVal(int position)
        {
            return darr.Get(position).getItems();
        }


        //Enqueuing/Dequeuing methods.
        public void Enq_back(int val)
        {
            darr.Add(new Customer(val), 0);
        }

        public Customer Deq_back()
        {
            var temp = darr.Remove(0);
            return temp;
        }

        public Customer Deq_front()
        {
            var temp = darr.Remove(darr.Size() - 1);
            return temp;
        }


        //helpful methods that simplify a LOT of the code.

        public void processItems()
        {
            int pos = darr.Size() - 1;
            int val = getCustomerVal(pos) - 1;

            if (val < 0) val = 0;
            setCustomerVal(pos, val);
        }

        //"Does the customer at the front has items to be processed?" method.
        public bool isCashierBored()
        {

            return getCustomerVal(darr.Size() - 1) <= 0;
        }

        //"Getting the customer's items at the front" method.
        public int getCashierWork()
        {
            return getCustomerVal(darr.Size() - 1);
        }

        //Size method.
        public int Size()
        {
            return darr.Size();
        }

        //And an isEmpty method for good measure.
        public bool isEmptyLine()
        {
            return darr.Size() == 0;
        }



    }

    //Simple customer class to get and set items of a given Customer.
    public class Customer
    {
        public int items;
        public Customer(int items)
        {
            this.items = items;
        }

        public void setItems(int val)
        {
            items = val;
        }


        public int getItems()
        {
            return items;
        }

        public override string ToString()
        {
            return "#: " + items;
        }

    }


    public class Store
    {
        Random rand = new Random();

        //yep, all of the code's in the constructor.
        //Some. How. the code doesn't run on my end without having to put it all in the constructor
        //I'll still document it and revisit it when I can.
        public Store(int numOfLines, int numCustomers)
        {
            //Initializing a array of lines to have an parameterized amount of lines
            //and filling it up.
            Line[] lines = new Line[numOfLines];
            for (int i = 0; i < numOfLines; i++)
            {
                lines[i] = new Line();

            }
            Console.WriteLine("Our store opens for business!");


            //randomly distributing the customers on throughout the lines
            //sometimes leads to odd distributions where one line has 0 items.
            for (int i = 0; i < numCustomers; i++)
            {
                lines[rand.Next(0, lines.Length)].Enq_back(rand.Next(1, 11));
                Console.WriteLine("Added " + (i + 1) + "th customer.");
            }

            //condensed print statement for 
            for (int w = 0; w < numOfLines; w++)
            {
                Console.WriteLine("line " + (w + 1) + ": " + lines[w].printLine());
            }
            Console.WriteLine("\n");

            int n = numCustomers;
            while (n > 0)
            {
                //iterate through all the lines
                for (int i = 0; i < lines.Length; i++)
                {
                    //if the current line has a customer with no items at the front.
                    if (lines[i].isCashierBored())
                    {
                        //if the line is almost finished, check other lines for available customers to serve
                        if (lines[i].Size() <= 1)
                        {
                            for (int j = 0; j < lines.Length; j++)
                            {
                                //checking if we're not on our current line and the line is more than 2 customers long.
                                if (i != j && lines[j].Size() > 2)
                                {
                                    var temp = lines[j].Deq_back();
                                    lines[i].Enq_back(temp.getItems());
                                }
                            }


                        }//else, process the customer and remove the customer
                        else
                        {
                            lines[i].Deq_front();
                            n--;
                        }

                    }

                    // odd snippet, but sometimes lines have empty customers that love buying items they go into debt 
                    // (they keep buying items to go into the negatives, even though the else statement SHOULD handle that
                    for (int k = 0; k < lines.Length; k++)
                    {
                        if (lines[i].Size() == 1 && lines[i].getCustomerVal(0) == 0)
                        {
                            n--;
                        }

                    }

                    lines[i].processItems();
                    //then our print statement per "operation" by cashier.
                    for (int w = 0; w < numOfLines; w++)
                    {
                        Console.WriteLine("line " + (w + 1) + ": " + lines[w].printLine() + "\n");
                    }



                }




            }


        }




    }
}

